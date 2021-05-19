using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessPlan;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProcessPlanService
{
    public class ProcessPlanService : IProcessPlanService
    {
        private readonly EnterpriseDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProcessPlanService(EnterpriseDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<GetAllProductGroup>> GetAllProductGroup()
        {
            var productGroup = await _context.ProductTypeGroups
                .Select(x => new GetAllProductGroup()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name
                }).ToListAsync();
            return new List<GetAllProductGroup>(productGroup);
        }

        public async Task<List<GetAllProductRecipes>> GetAllProductRecipes(int id, string key)
        {
            var productRecipes = await _context.Products
                .Include(x => x.Recipes)
                .Where(x => x.IdProductType == id && (x.Name.Contains(key) || x.Code.Contains(key)))
                .Select(x => new GetAllProductRecipes()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Amount = x.Amount,
                    Max = x.Max == null ? 0 : x.Max,
                    AllRecipes = x.Recipes.OrderByDescending(r => r.Prioritize)
                    .Select(r => new AllRecipes()
                    {
                        IdRecipes = r.Id,
                        Code = r.Code,
                        Name = r.Name
                    }).ToList()
                }).ToListAsync();
            return new List<GetAllProductRecipes>(productRecipes);
        }

        public async Task<List<GetAllProductType>> GetAllProductType(int id)
        {
            var productType = await _context.ProductTypes
                 .Where(x => x.Id == id)
                 .Select(x => new GetAllProductType()
                 {
                     Id = x.Id,
                     Code = x.Code,
                     Name = x.Name
                 }).ToListAsync();
            return new List<GetAllProductType>(productType);
        }

        public async Task<List<GetEmployee>> GetEmployee(string key)
        {
            var user = _userManager.Users
                .Where(x => (x.FirstName.Contains(key) || x.LastName.Contains(key) || x.Code.Contains(key)
                || x.Card.Contains(key)) && x.JobStatus == JobStatus.Working);

            var result = await user.Select(x => new GetEmployee()
            {
                Id = x.Id,
                Code = x.Code,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Card = x.Card
            }).ToListAsync();

            return new List<GetEmployee>(result);
        }

        public async Task<List<GetListPacksById>> GetListPacksById(int id)
        {
            var pack = await _context.Products.Include(x => x.Packs)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            var result = pack.Packs.Select(
                x => new GetListPacksById()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Default = x.Default,
                    Value = x.Value
                }).ToList();
            return new List<GetListPacksById>(result);
        }

        public async Task<List<GetListPacksProduct>> GetListPacksProduct(int id)
        {
            var packs = _context.Packs.Where(x => x.IdProduct == id);

            var result = await packs.Select(x => new GetListPacksProduct()
            {
                Id = x.Id,
                Name = x.Name,
                Default = x.Default
            }
            ).ToListAsync();

            return new List<GetListPacksProduct>(result);
        }

        public async Task<ApiResult<bool>> Create(CreatePlan bundle)
        {
            var processingDetails = new List<ProcessingDetail>();

            if (bundle.Pack.Length > 0)
            {
                var i = 0;
                foreach (var item in bundle.Pack)
                {
                    processingDetails.Add(new ProcessingDetail()
                    {
                        Amount = bundle.Amount[i],
                        IdRecipe = bundle.IdMaterials[i],
                        Unit = item
                    });

                    i++;
                }
            }
            // lưu code
            var user = await _userManager.FindByNameAsync(bundle.NameCreator);

            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var checkCode = await _context.OrderPlans.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            // kế hoạch

            var process = new ProcessPlan()
            {
                Code = str,
                CreatedDate = DateTime.Now,
                ExpectedDate = bundle.ExpectedDate,
                Note = bundle.Note,
                IdCreator = user.Id,
                IdResponsible = bundle.IdResponsible,
                ProcessingDetails = processingDetails,
                Name = bundle.Name
            };

            _context.ProcessPlans.Update(process);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetByProcessPlanCensorship>> GetByProcessPlanCensorship()
        {
            var process = _context.ProcessPlans.Include(x => x.ProcessingDetails)
                .ThenInclude(x => x.Recipe)
                .Where(x => x.Censorship == false);

            process = process.Include(x => x.Creator);
            process = process.Include(x => x.Responsible);

            var count = await process.CountAsync();
            var reuslt = await process.Select(x => new GetByProcessPlanCensorship()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Censorship = x.Censorship,
                CreatedDate = x.CreatedDate.ToString("dd-MM-yyyy"),
                ExpectedDate = x.ExpectedDate.ToString("dd-MM-yyyy"),
                Note = x.Note == null ? "" : x.Note,
                Status = x.Status == StatusProcessPlan.Processing ? "Đang chế biến"
                        : x.Status == StatusProcessPlan.Processing ? "Đã chế biến" : "Đã hủy",
                IdCreator = x.IdCreator,
                CodeCreator = x.Creator.Code,
                IdResponsible = x.IdResponsible,
                CodeResponsible = x.Responsible.Code,
                NameResponsible = x.Responsible.UserName,
                Duration = x.ExpectedDate.Date >= DateTime.Now.Date ? true : false,
                Count = count,
                ListProcessingDetails = x.ProcessingDetails.Select(p => new ListProcessingDetail()
                {
                    Id = p.Id,
                    Amount = p.Amount,
                    Unit = p.Unit,
                    IdRecipe = p.IdRecipe,
                    CodeRecipe = p.Recipe.Code
                }).ToList()
            }).ToListAsync();

            return new List<GetByProcessPlanCensorship>(reuslt);
        }

        public async Task<ApiResult<PagedResult<ProcessPlanVm>>> GetProcessPlanPaging(GetProcessPlanPagingRequest bundle)
        {
            IQueryable<ProcessPlan> query = _context.ProcessPlans;

            if (!string.IsNullOrEmpty(bundle.Status))
            {
                switch (bundle.Status)
                {
                    case "true":
                        query = query.Where(c => c.Status == StatusProcessPlan.Processed);
                        break;

                    case "false":
                        query = query.Where(c => c.Status == StatusProcessPlan.Cancel);
                        break;
                }
            }

            query = query.Where(c => c.Status != StatusProcessPlan.Processing);

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.Name.Contains(bundle.Keyword) || c.Code.Contains(bundle.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.Id);

            var query1 = query.Include(x => x.Creator);
            var query2 = query1.Include(l => l.Responsible);

            var data = await query2.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(i => new ProcessPlanVm()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name,
                    Status = i.Status == StatusProcessPlan.Processed ? "Đã hoàn thành" :
                         i.Status == StatusProcessPlan.Cancel ? "Đã hủy" : "Đang chế biến",
                    CreatedDate = i.CreatedDate.ToString("dd-MM-yyyy"),
                    CodeCreator = i.Creator.Code,
                    CodeResponsible = i.Responsible.Code
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProcessPlanVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProcessPlanVm>>(pagedResult);
        }

        public async Task<ApiResult<GetProcessPlanByIdRecipes>> GetProcessPlanByIdRecipes(long id)
        {
            var process = _context.ProcessPlans
               .Include(x => x.ProcessingDetails)
               .Where(x => x.Id == id);
            if (process == null)
            {
                return new ApiErrorResult<GetProcessPlanByIdRecipes>("Kế hoạch không tồn tại");
            }

            process = process.Include(x => x.Creator);
            process = process.Include(x => x.Responsible);
            process = process.Include(x => x.Authority);

            var result = await process.Select(x => new GetProcessPlanByIdRecipes
            {
                DateMan = x.ExpectedDate.ToString("yyyy-MM-dd"),
                ExpectedDate = x.ExpectedDate.ToString("dd-MM-yyyy"),
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Status = x.Status == StatusProcessPlan.Processed ? "Đã hoàn thành" :
                         x.Status == StatusProcessPlan.Cancel ? "Đã hủy" : "Đang chế biến",
                CreatedDate = x.CreatedDate.ToString("dd-MM-yyyy"),
                CodeCreator = x.Creator.Code,
                CodeResponsible = x.Responsible.Code,
                CodeAuthority = x.Authority.Code,
                ListProcessingDetails = x.ProcessingDetails.Select(p => new ListProcessingDetailRecipes
                {
                    Id = p.Id,
                    CodeRecipe = p.Recipe.Code,
                    IdRecipe = p.IdRecipe,
                    Amount = p.Amount,
                    Unit = p.Unit
                }).ToList()
            }).FirstOrDefaultAsync();

            return new ApiSuccessResult<GetProcessPlanByIdRecipes>(result);
        }

        public async Task<ApiResult<GetProcessPlanById>> GetProcessPlanById(long id)
        {
            var processPlan = await _context.ProcessPlans
                .Include(x => x.Responsible)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = new GetProcessPlanById()
            {
                Id = processPlan.Id,
                Code = processPlan.Code,
                DateMan = processPlan.ExpectedDate.ToString("yyyy-MM-dd"),
                ExpectedDate = processPlan.ExpectedDate.ToString("dd-MM-yyyy"),
                Duration = processPlan.ExpectedDate.Date >= DateTime.Now.Date ? true : false,
                Name = processPlan.Name,
                Note = processPlan.Note,
                NameResponsible = processPlan.Responsible.UserName,
                IdResponsible = processPlan.IdResponsible,
                CodeResponsible = processPlan.Responsible.Code
            };

            return new ApiSuccessResult<GetProcessPlanById>(result);
        }

        public async Task<ApiResult<long>> Update(UpdatePlan bundle)
        {
            var order = await _context.ProcessPlans.FindAsync(bundle.Id);

            order.Name = bundle.Name;
            order.Note = bundle.Note;
            order.IdResponsible = bundle.IdResponsible;
            order.ExpectedDate = bundle.ExpectedDate;

            _context.ProcessPlans.Update(order);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<long>(order.Id);
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var order = await _context.ProcessPlans
                .Include(x => x.ProcessingDetails)
                .FirstAsync(x => x.Id == id);
            if (order == null)
            {
                return new ApiErrorResult<bool>("Kế hoạch không tồn tại");
            }
            _context.ProcessPlans.Remove(order);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetByProcessPlanCensorship>> GetByProcessPlanApproved(string key)
        {
            var order = _context.ProcessPlans;
            order.Include(x => x.ProcessingDetails);
            var cr = order.Include(g => g.Creator);

            var re = cr.Include(t => t.Responsible).Where(t => t.Responsible.UserName == key);

            re = re.OrderByDescending(x => x.Id);
            re = re.Where(o => (o.Censorship == true && o.Status == StatusProcessPlan.Processing));
            var count = await re.CountAsync();

            var result = await re.Select(o => new GetByProcessPlanCensorship()
            {
                Id = o.Id,
                Code = o.Code,
                Name = o.Name,
                Censorship = o.Censorship,
                CreatedDate = o.CreatedDate.ToString("dd-MM-yyyy"),
                ExpectedDate = o.ExpectedDate.ToString("dd-MM-yyyy"),
                Duration = o.ExpectedDate.Date >= DateTime.Now.Date ? true : false,
                Note = o.Note == null ? "" : o.Note,
                IdCreator = o.IdCreator,
                CodeCreator = o.Creator.Code,
                IdResponsible = o.IdResponsible,
                CodeResponsible = o.Responsible.Code,
                Count = count,
                NameResponsible = o.Responsible.UserName,
                Status = o.Status == StatusProcessPlan.Processed ? "Đã hoàn thành" :
                         o.Status == StatusProcessPlan.Cancel ? "Đã hủy" : "Đang chế biến",
                ListProcessingDetails = o.ProcessingDetails.Select(
                  i => new ListProcessingDetail()
                  {
                      Id = i.Id,
                      CodeRecipe = i.Recipe.Code,
                      Amount = i.Amount,
                      Unit = i.Unit,
                      IdRecipe = i.IdRecipe,
                  }).ToList()
            }).ToListAsync();

            return new List<GetByProcessPlanCensorship>(result);
        }

        public async Task<List<GetMaterialsByRecipes>> GetMaterialsByRecipes(int idRecipe)
        {
            var recipe = _context.RecipeDetails.Include(x => x.Material)
                .Where(x => x.IdRecipe == idRecipe);

            var result = await recipe.Select(x => new GetMaterialsByRecipes()
            {
                Code = x.Material.Code,
                Name = x.Material.Name,
                Amount = x.Amount,
                Unit = x.Unit
            }).ToListAsync();

            return new List<GetMaterialsByRecipes>(result);
        }

        public async Task<ApiResult<bool>> UpdateProcessPlanCensorship(UpdateCensorship bundle)
        {
            var process = await _context.ProcessPlans.FindAsync(bundle.Id);
            if (process == null)
            {
                return new ApiErrorResult<bool>("Kế hoạch không tồn tại");
            }
            var au = await _userManager.FindByNameAsync(bundle.Authority);
            process.IdAuthority = au.Id;
            process.Censorship = true;

            _context.ProcessPlans.Update(process);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}