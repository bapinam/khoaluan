using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessingDetail;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<ApiResult<bool>> SplitProcess(long id)
        {
            var process = await _context.ProcessPlans
                .Include(x => x.ProcessingDetails)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            var listProcessingDetails = new List<ProcessingDetail>();

            foreach (var item in process.ProcessingDetails)
            {
                var amount = item.Amount - item.EnterAmount;
                if (amount > 0)
                {
                    var processingDetails = new ProcessingDetail()
                    {
                        Amount = amount,
                        IdRecipe = item.IdRecipe,
                        IdProcessPlan = item.IdProcessPlan,
                        Unit = item.Unit
                    };
                    listProcessingDetails.Add(processingDetails);
                }
            }

            var stt = 1;
            Location:
            string code = process.Code + "-" + stt.ToString();

            var checkCode = await _context.ProcessPlans.AnyAsync(x => x.Code == code);
            if (checkCode)
            {
                stt++;
                goto Location;
            }

            var processPlan = new ProcessPlan()
            {
                Code = code,
                IdAuthority = process.IdAuthority,
                IdCreator = process.IdCreator,
                IdResponsible = process.IdResponsible,
                Censorship = false,
                CreatedDate = DateTime.Now,
                ExpectedDate = DateTime.Now,
                Name = process.Name + " (Tách)",
                Note = process.Note,
                Status = StatusProcessPlan.Processing,
                ProcessingDetails = listProcessingDetails
            };

            _context.ProcessPlans.Add(processPlan);
            await _context.SaveChangesAsync();

            process.Status = StatusProcessPlan.Processed;
            var note = process.Note + " (Đã từng tách kế hoạch)";
            process.Note = note;
            _context.ProcessPlans.Update(process);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<ListProcessingVoucher>> GetMarkProcessing(string key)
        {
            var process = _context.ProcessingVouchers.Include(x => x.ProcessingVoucherDetails)
                .Include(x => x.ProcessPlan).Include(x => x.Creator);

            IQueryable<ProcessingVoucher> processResult;
            if (!string.IsNullOrEmpty(key))
            {
                processResult = process
                               .Include(x => x.ProcessPlan.Responsible)
                               .Where(x => x.Code.Contains(key) || x.ProcessPlan.Code.Contains(key)
                               || x.ProcessPlan.Responsible.Code.Contains(key));
            }
            else
            {
                processResult = process.Include(x => x.ProcessPlan.Responsible);
            }

            processResult = processResult.Where(x => x.Status == false);
            var count = await processResult.CountAsync();
            var data = await processResult
                .Select(x => new ProcessingVoucherVm()
                {
                    Id = x.Id,
                    Code = x.Code,
                    CreateDate = x.CreateDate.ToString("dd-MM-yyyy"),
                    IdPlan = x.IdPlan,
                    CodePlan = x.ProcessPlan.Code,
                    Creator = x.Creator.Code,
                    NameResponsible = x.ProcessPlan.Responsible.Code
                }).ToListAsync();

            var result = new ListProcessingVoucher()
            {
                Count = count,
                ProcessingVoucherVms = data
            };

            return new ApiSuccessResult<ListProcessingVoucher>(result);
        }

        public async Task<ApiResult<bool>> ChangeMarkStatus(long id)
        {
            var voucher = await _context.ProcessingVouchers.FindAsync(id);
            if (voucher == null)
            {
                return new ApiErrorResult<bool>("Phiếu không tồn tại");
            }
            voucher.Status = true;
            voucher.CompleteDate = DateTime.Now;
            _context.ProcessingVouchers.Update(voucher);
            await _context.SaveChangesAsync();

            // cập nhật số lượng sản phẩm:
            List<Product> products = new List<Product>();
            var recipes = await _context.ProcessingVoucherDetails.Include(x => x.Recipe)
                .Where(x => x.IdVoucher == id).ToListAsync();

            foreach (var item in recipes)
            {
                var product = await _context.Products.Include(x => x.Packs)
                   .Where(x => x.Id == item.Recipe.IdProduct).FirstOrDefaultAsync();
                var unit = product.Packs.Where(x => x.Name == item.Unit).FirstOrDefault();
                // số lượng
                var amount = unit.Value * item.Amount;
                var productNew = amount + product.Amount;
                product.Amount = productNew;
                products.Add(product);
            }
            _context.Products.UpdateRange(products);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            List<Material> materialsListUpdate = new List<Material>();
            List<Product> productListUpdate = new List<Product>();
            List<ProcessingDetail> processingDetailListUpdate = new List<ProcessingDetail>();

            var voucher = await _context.ProcessingVouchers
                .Include(x => x.ProcessingVoucherDetails)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            if (voucher == null)
            {
                return new ApiErrorResult<bool>("Phiếu không tồn tại");
            }

            var processPlan = await _context.ProcessPlans.Include(x => x.ProcessingDetails)
                    .Where(x => x.Id == voucher.IdPlan).FirstAsync();
            //cộng lại số lượng

            foreach (var detail in voucher.ProcessingVoucherDetails)
            {
                var recipe = await _context.Recipes.Include(x => x.RecipeDetails)
                    .Where(x => x.Id == detail.IdRecipe).FirstOrDefaultAsync();

                foreach (var recipeDetail in recipe.RecipeDetails)
                {
                    var materials = await _context.Materials.Include(x => x.Packs)
                        .Where(x => x.Id == recipeDetail.IdMaterials).FirstOrDefaultAsync();
                    var unit = materials.Packs.Where(x => x.Name == recipeDetail.Unit).FirstOrDefault();
                    var amount = recipeDetail.Amount * unit.Value * detail.Amount;
                    // cập nhật số lượng nguyên vật liệu (giảm)
                    var amountMaterNew = materials.Amount + amount;
                    materials.Amount = amountMaterNew;
                    materialsListUpdate.Add(materials);
                }

                // cập nhật lại số lượng sản phẩm (tăng)
                var product = await _context.Products.Include(x => x.Packs)
                  .Where(x => x.Id == detail.Recipe.IdProduct).FirstOrDefaultAsync();
                var unitProduct = product.Packs.Where(x => x.Name == detail.Unit).FirstOrDefault();
                var amountProduct = unitProduct.Value * detail.Amount;
                var amountProductNew = product.Amount - amountProduct;
                product.Amount = amountProductNew;
                productListUpdate.Add(product);

                // cập nhật số lượng kế hoạch

                var processingDetails = processPlan.ProcessingDetails.Where(x => x.IdRecipe == recipe.Id).FirstOrDefault();
                var amountPlanEnterNew = processingDetails.EnterAmount - detail.Amount;
                processingDetails.EnterAmount = amountPlanEnterNew;
                processingDetails.Status = false;
                processingDetailListUpdate.Add(processingDetails);
            }

            processPlan.Status = StatusProcessPlan.Processing;
            _context.ProcessPlans.Update(processPlan);

            _context.Materials.UpdateRange(materialsListUpdate);
            _context.Products.UpdateRange(productListUpdate);
            _context.ProcessingDetails.UpdateRange(processingDetailListUpdate);

            _context.ProcessingVouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<ProcessingVoucherVm>>> GetProcessComplete(GetProcessCompletePaging bundle)
        {
            var process = _context.ProcessingVouchers.Include(x => x.ProcessingVoucherDetails)
                .Include(x => x.ProcessPlan).Include(x => x.Creator);

            IQueryable<ProcessingVoucher> processResult;
            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                processResult = process
                               .Include(x => x.ProcessPlan.Responsible)
                               .Where(x => x.Code.Contains(bundle.Keyword) || x.ProcessPlan.Code.Contains(bundle.Keyword)
                               || x.ProcessPlan.Responsible.Code.Contains(bundle.Keyword));
            }
            else
            {
                processResult = process.Include(x => x.ProcessPlan.Responsible);
            }

            processResult = processResult.Where(x => x.Status == true);
            int totalRow = await processResult.CountAsync();

            var data = await processResult
                .Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(x => new ProcessingVoucherVm()
                {
                    Id = x.Id,
                    Code = x.Code,
                    CreateDate = x.CreateDate.ToString("dd-MM-yyyy"),
                    IdPlan = x.IdPlan,
                    CodePlan = x.ProcessPlan.Code,
                    Creator = x.Creator.Code,
                    NameResponsible = x.ProcessPlan.Responsible.Code
                }).ToListAsync();

            var pagedResult = new PagedResult<ProcessingVoucherVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<ProcessingVoucherVm>>(pagedResult);
        }

        public async Task<ApiResult<GetViewProcessingVocher>> GetViewProcessingVocher(long id)
        {
            var view = await _context.ProcessingVouchers.Include(x => x.ProcessingVoucherDetails)
                .ThenInclude(x => x.Recipe).ThenInclude(x => x.Product)
                .Include(x => x.ProcessPlan).Include(x => x.Creator)
                .Include(x => x.ProcessPlan.Responsible)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            var result = new GetViewProcessingVocher()
            {
                Id = view.Id,
                Code = view.Code,
                CodePlan = view.ProcessPlan.Code,
                CodeCreator = view.Creator.Code,
                CodeResponsible = view.ProcessPlan.Responsible.Code,
                CreateDate = view.CreateDate.ToString("dd-MM-yyyy"),
                CompleteDate = view.CompleteDate.ToString("dd-MM-yyyy"),
                Status = view.Status,
                ListRecipes = view.ProcessingVoucherDetails.Select(x => new ListRecipes()
                {
                    IdRecipes = x.IdRecipe,
                    Amount = x.Amount,
                    Unit = x.Unit,
                    CodeProduct = x.Recipe.Product.Code,
                    CodeRecipes = x.Recipe.Code,
                    NameProduct = x.Recipe.Product.Name
                }).ToList()
            };

            return new ApiSuccessResult<GetViewProcessingVocher>(result);
        }
    }
}