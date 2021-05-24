using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessingDetail;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProcessingDetailService
{
    public class ProcessingDetailService : IProcessingDetailService
    {
        private readonly EnterpriseDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProcessingDetailService(EnterpriseDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApiResult<ProcessingPlanVmCount>> GetDistributing(string key)
        {
            IQueryable<ProcessPlan> query = _context.ProcessPlans.Include(x => x.Responsible);

            query = query.Where(c => c.Status == StatusProcessPlan.Processing && c.Censorship == true);

            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(c => c.Name.Contains(key) || c.Code.Contains(key)
                                    || c.Responsible.Code.Contains(key));
            }

            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.Id);

            var data = await query
                .Select(i => new ProcessingPlanVm()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name,
                    CreatedDate = i.CreatedDate.ToString("dd-MM-yyyy"),
                    CodeResponsible = i.Responsible.Code,
                }).ToListAsync();

            var reuslt = new ProcessingPlanVmCount()
            {
                Count = totalRow,
                ProcessingPlanVms = data
            };
            return new ApiSuccessResult<ProcessingPlanVmCount>(reuslt);
        }

        public async Task<List<ProcessingDetailVm>> GetAllProcessDetailById(long id)
        {
            var process = _context.ProcessingDetails.Include(x => x.Recipe)
                .ThenInclude(x => x.RecipeDetails).ThenInclude(x => x.Material)
                .Where(x => x.IdProcessPlan == id && !x.Status);

            process = process.Include(x => x.Recipe.Product);

            var result = await process.Select(x => new ProcessingDetailVm()
            {
                IdProcess = x.Id,
                CodeProduct = x.Recipe.Product.Code,
                NameProduct = x.Recipe.Product.Name,
                AmountProcess = x.Amount,
                EnterAmountProcess = x.EnterAmount,
                UnitProcess = x.Unit,
                IdRecipes = x.IdRecipe,
                CodeRecipes = x.Recipe.Code,
                RecipeMaterials = x.Recipe.RecipeDetails.Select(r => new RecipeMaterials()
                {
                    IdMaterials = r.IdMaterials,
                    CodeMaterials = r.Material.Code,
                    NameMaterials = r.Material.Name,
                    AmountMaterials = r.Material.Amount,
                    AmountRecipe = r.Amount,
                    UnitRecipe = r.Unit,
                    ValuePack = r.Material.Packs
                    .Where(x => x.IdMaterials == r.IdMaterials && x.Name == r.Unit)
                    .Select(x => x.Value)
                    .First()
                }).ToList()
            }).ToListAsync();

            return new List<ProcessingDetailVm>(result);
        }

        public async Task<ApiResult<PagedResult<ProcessingPlanVm>>>
            GetProcessingCompleted(GetDistributingPagingRequest bundle)
        {
            IQueryable<ProcessPlan> query = _context.ProcessPlans.Include(x => x.Responsible);

            query = query.Where(c => c.Status == StatusProcessPlan.Processing && c.Censorship == true);

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.Name.Contains(bundle.Keyword) || c.Code.Contains(bundle.Keyword)
                                    || c.Responsible.Code.Contains(bundle.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.Id);

            query = query.Include(x => x.Creator).Include(l => l.Responsible);

            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(i => new ProcessingPlanVm()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name,
                    CreatedDate = i.CreatedDate.ToString("dd-MM-yyyy"),
                    CodeResponsible = i.Responsible.Code,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProcessingPlanVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProcessingPlanVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Create(CreateProcess bundle)
        {
            List<ProcessingVoucherDetail> processVoucherDetilList = new List<ProcessingVoucherDetail>();
            List<Material> materialsUpdate = new List<Material>();
            List<ProcessingDetail> processingDetailUpdate = new List<ProcessingDetail>();

            int i = 0;
            foreach (var item in bundle.Amount)
            {
                if (item != 0)
                {
                    var process = await _context.ProcessingDetails
                        .Include(x => x.Recipe).ThenInclude(x => x.RecipeDetails)
                        .Where(x => x.Id == bundle.IdProcess[i]).FirstOrDefaultAsync();

                    foreach (var it in process.Recipe.RecipeDetails)
                    {
                        var materials = await _context.Materials.Include(x => x.Packs)
                            .Where(x => x.Id == it.IdMaterials).FirstOrDefaultAsync();

                        var unit = materials.Packs.Where(x => x.Name == it.Unit).FirstOrDefault();
                        long recipesDetailsAmount = 0;
                        // tính số lượng vừa nhập,ý là số lượng sẽ phát
                        recipesDetailsAmount = item * it.Amount * unit.Value;

                        if (recipesDetailsAmount > materials.Amount || materials.Amount == 0)
                        {
                            string str = $"Không thể tạo, vì số lượng {materials.Name} không đủ.";
                            return new ApiErrorResult<bool>(str);
                        }
                        // cập nhật lại số lượng  trong nguyên vật liệu
                        var amountMaterialNew = materials.Amount - recipesDetailsAmount;
                        materials.Amount = amountMaterialNew < 0 ? 0 : amountMaterialNew;
                        materialsUpdate.Add(materials);
                    }

                    // thêm số lượng sản phẩm đã được dx nhận nguyên liệu để tạo phiếu
                    var processVD = new ProcessingVoucherDetail()
                    {
                        Amount = item,
                        IdRecipe = process.IdRecipe,
                        Unit = process.Unit
                    };
                    processVoucherDetilList.Add(processVD);

                    // cập nhật số lượng đã thêm trong kế hoạch chi tiết chế biến.
                    var enterOld = process.EnterAmount;
                    var enterNew = process.EnterAmount + item;
                    process.EnterAmount = enterNew;
                    var total = process.Amount - enterNew;
                    if (total <= 0)
                    {
                        process.Status = true;
                    }
                    else
                    {
                        process.Status = false;
                    }
                    processingDetailUpdate.Add(process);
                }
                i++;
            }
            // tìm id user
            var user = await _userManager.FindByNameAsync(bundle.NameCreator);
            if (user == null)
            {
                return new ApiErrorResult<bool>();
            }
            // tạo code
            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            var stt = 1;
            Location:
            var location = code.Location + stt;

            var strCode = code.Name + location;

            var checkCode = await _context.ProductTypes.AnyAsync(x => x.Code == strCode);
            if (checkCode)
            {
                stt++;
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            //cập nhật kế hoạch chế biến đã hoàn thành  phát

            var processVoucher = new ProcessingVoucher()
            {
                Code = strCode,
                IdCreator = user.Id,
                IdPlan = bundle.IdPlan,
                ProcessingVoucherDetails = processVoucherDetilList
            };
            // cập nhật và khởi tạo

            _context.Materials.UpdateRange(materialsUpdate);
            _context.ProcessingDetails.UpdateRange(processingDetailUpdate);

            _context.ProcessingVouchers.Add(processVoucher);

            await _context.SaveChangesAsync();

            var processNew = await _context.ProcessPlans.Include(x => x.ProcessingDetails)
                .Where(x => x.Id == bundle.IdPlan).FirstOrDefaultAsync();
            var status = true;
            foreach (var p in processNew.ProcessingDetails)
            {
                if (!p.Status)
                {
                    status = false;
                    break;
                }
            }
            if (status)
            {
                processNew.Status = StatusProcessPlan.Processed;
                _context.ProcessPlans.Update(processNew);
                await _context.SaveChangesAsync();
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> CancelProcess(long id)
        {
            var process = await _context.ProcessPlans.FindAsync(id);
            if (process == null)
            {
                return new ApiErrorResult<bool>("Kế hoạch không tồn tại");
            }

            var voucher = await _context.ProcessingVouchers.Where(x => x.IdPlan == id).CountAsync();
            if (voucher < 1)
            {
                process.Status = StatusProcessPlan.Cancel;
                _context.ProcessPlans.Update(process);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>
                ("Hủy thất bại, vì có phiếu chế biến tồn tại một phần kế hoạch. Vui lòng tách!");
        }
    }
}