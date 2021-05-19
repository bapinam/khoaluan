using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Recipe;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.Service.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;

        public RecipeService(EnterpriseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<PagedResult<ProductRecipe>>> GetRecipePaging(GetRecipePagingRequest bundle)
        {
            var query = from s in _context.Products
                        join g in _context.ProductTypes on s.IdProductType equals g.Id
                        join d in _context.Recipes on s.Id equals d.IdProduct into r
                        from d in r.DefaultIfEmpty()
                        where d.Prioritize != false
                        select new
                        {
                            s,
                            d = (d == null) ? "Chưa có công thức" : d.Name,
                            g
                        };

            if (bundle.ProductType > 0)
            {
                query = query.Where(x => x.g.Id == bundle.ProductType);
            }

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.s.Name.Contains(bundle.Keyword) || c.s.Code.Contains(bundle.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.s.Id);
            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(i => new ProductRecipe()
                {
                    Id = i.s.Id,
                    Code = i.s.Code,
                    Name = i.s.Name,
                    Image = i.s.Image,
                    NameProductType = i.g.Name,
                    NameRecipe = i.d
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductRecipe>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<ProductRecipe>>(pagedResult);
        }

        public async Task<List<GetListRecipe>> GetListRecipe(int id)
        {
            var recipes = await _context.Recipes.Include(rd => rd.RecipeDetails)
                .ThenInclude(m => m.Material).Where(x => x.IdProduct == id).ToListAsync();

            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(products, Newtonsoft.Json.Formatting.None,
            //    new Newtonsoft.Json.JsonSerializerSettings()
            //    {
            //        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //    });

            var result = recipes
                .OrderByDescending(x => x.Prioritize)
                .Select(i => new GetListRecipe()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name,
                    Prioritize = i.Prioritize,
                    Note = i.Note,
                    IngredientRecipes = i.RecipeDetails.Select(x => new IngredientRecipe()
                    {
                        Id = x.Id,
                        Amount = x.Amount,
                        Unit = x.Unit,
                        Name = x.Material.Name
                    }).ToList()
                }).ToList();

            return new List<GetListRecipe>(result);
        }

        public async Task<ApiResult<bool>> iName(string name, int idSP, int? id)
        {
            bool count;
            if (id != null)
            {
                count = await _context.Recipes
                    .Where(x => x.IdProduct == idSP && x.Id != id)
                   .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                   SystemConstants.Collate_AS) == name.ToUpper().Trim());
            }
            else
            {
                count = await _context.Recipes
                   .Where(x => x.IdProduct == idSP)
                  .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                  SystemConstants.Collate_AS) == name.ToUpper().Trim());
            }

            if (count)
            {
                return new ApiErrorResult<bool>("Tên đóng gói đã tồn tại");
            }
            else
            {
                return new ApiSuccessResult<bool>();
            }
        }

        public async Task<List<GetMaterialsType>> GetMaterialsType(GroupType? group)
        {
            var materialsType = _context.MaterialsTypes;

            List<GetMaterialsType> result;
            if (group != null)
            {
                result = await materialsType.Where(x => x.GroupType == group)
                    .Select(x => new GetMaterialsType()
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name
                    }).ToListAsync();
            }
            else
            {
                result = await materialsType
                    .Select(x => new GetMaterialsType()
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name
                    }).ToListAsync();
            }

            return new List<GetMaterialsType>(result);
        }

        public async Task<List<GetListMaterials>> GetListMaterials(ListBundleMaterials bundle)
        {
            var materialsType = _context.Materials.Include(x => x.MaterialsType);

            List<GetListMaterials> result;
            if (bundle.GroupTypeMaterials != null)
            {
                result = await materialsType
                    .Where(
                        x => x.MaterialsType.GroupType == bundle.GroupTypeMaterials
                        && x.IdMaterialsType == bundle.MaterialsType
                        && (x.Name.Contains(bundle.KeyWordNL)
                        || x.Code.Contains(bundle.KeyWordNL)))
                    .Select(x => new GetListMaterials()
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name,
                        Image = x.Image,
                        NameType = x.MaterialsType.Name
                    }).ToListAsync();
            }
            else
            {
                result = await materialsType
                     .Where(x => x.IdMaterialsType == bundle.MaterialsType
                     && (x.Name.Contains(bundle.KeyWordNL)
                        || x.Code.Contains(bundle.KeyWordNL)))
                    .Select(x => new GetListMaterials()
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name,
                        Image = x.Image,
                        NameType = x.MaterialsType.Name
                    }).ToListAsync();
            }

            return new List<GetListMaterials>(result);
        }

        public async Task<List<GetListPacksProduct>> GetListPacks(int id)
        {
            var packs = _context.Packs.Where(x => x.IdMaterials == id);

            var result = await packs.Select(x => new GetListPacksProduct()
            {
                Id = x.Id,
                Name = x.Name,
                Default = x.Default
            }
            ).ToListAsync();

            return new List<GetListPacksProduct>(result);
        }

        public async Task<ApiResult<GetCreateRecipe>> Create(CreateRecipe bundle)
        {
            var count = _context.Recipes.Where(x => x.IdProduct == bundle.IdProduct).Count();
            if (count < 1)
            {
                bundle.Prioritize = true;
            }

            if (bundle.Prioritize)
            {
                var check = await _context.Recipes
               .AnyAsync(x => x.IdProduct == bundle.IdProduct && x.Prioritize == true);

                if (check)
                {
                    var reciper = await _context.Recipes
                        .FirstAsync(x => x.IdProduct == bundle.IdProduct && x.Prioritize == true);

                    reciper.Prioritize = false;
                    _context.Recipes.Update(reciper);
                }
            }

            var recipeDetail = new List<RecipeDetail>();
            if (bundle.IdMaterials != null)
            {
                int i = 0;
                foreach (int item in bundle.IdMaterials)
                {
                    recipeDetail.Add(new RecipeDetail()
                    {
                        IdMaterials = item,
                        Amount = bundle.Amount[i],
                        Unit = bundle.Unit[i]
                    });
                    i++;
                }
            }

            var recipe = new Recipe()
            {
                Name = bundle.Name,
                Note = bundle.Note,
                Prioritize = bundle.Prioritize,
                IdProduct = bundle.IdProduct,
                RecipeDetails = recipeDetail
            };

            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var checkCode = await _context.Recipes.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            recipe.Code = str;

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            var result = new GetCreateRecipe()
            {
                IdProduct = recipe.IdProduct,
                NameRecipe = recipe.Name,
                Prioritize = recipe.Prioritize
            };
            return new ApiSuccessResult<GetCreateRecipe>(result);
        }

        public async Task<ApiResult<string>> UpdatePrioritizeRecipe(UpdatePrioritizeRecipe bundle)
        {
            var reciper = await _context.Recipes
                       .FirstAsync(x => x.IdProduct == bundle.IdProduct && x.Prioritize == true);

            reciper.Prioritize = false;
            _context.Recipes.Update(reciper);

            var prioritize = await _context.Recipes.FirstAsync(x => x.Id == bundle.Id);
            prioritize.Prioritize = true;
            _context.Recipes.Update(prioritize);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<string>(prioritize.Name);
        }

        public async Task<ApiResult<string>> Delete(int id, int idProuduct)
        {
            string result;
            var check = await _context.Recipes.AnyAsync(x => x.Id == id && x.Prioritize == true);
            if (check)
            {
                var proudct = _context.Recipes
                    .Where(x => x.IdProduct == idProuduct).Count();

                if (proudct > 1)
                {
                    var list = await _context.Recipes
                   .FirstAsync(x => x.IdProduct == idProuduct && x.Prioritize == false);

                    list.Prioritize = true;
                    _context.Recipes.Update(list);
                    result = list.Name;
                }
                else
                {
                    result = "Chưa có công thức";
                }
            }
            else
            {
                result = "";
            }

            var reciper = await _context.Recipes.Include(x => x.RecipeDetails)
                .FirstAsync(x => x.Id == id);

            _context.Recipes.Remove(reciper);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<string>(result);
        }

        public async Task<ApiResult<GetListIdRecipe>> GetListIdRecipe(int id)
        {
            var check = await _context.Recipes.FindAsync(id);
            if (check == null)
            {
                return new ApiErrorResult<GetListIdRecipe>();
            }
            var recipes = _context.Recipes.Include(x => x.RecipeDetails)
                .ThenInclude(x => x.Material)
                .Where(x => x.Id == id);

            var result = await recipes.Select(x => new GetListIdRecipe()
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Prioritize = x.Prioritize,
                Note = x.Note,
                IngredientRecipes = x.RecipeDetails.Select(i => new IngredientRecipe()
                {
                    Id = i.Id,
                    Name = i.Material.Name,
                    Amount = i.Amount,
                    Unit = i.Unit
                }).ToList()
            }).FirstAsync();

            return new ApiSuccessResult<GetListIdRecipe>(result);
        }

        public async Task<ApiResult<bool>> DeleteMaterials(long id)
        {
            var delete = await _context.RecipeDetails.FindAsync(id);
            if (delete == null)
            {
                return new ApiErrorResult<bool>("Dữ liệu không tồn tại");
            }

            _context.RecipeDetails.Remove(delete);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> iMaterials(int idRecipe, int idMaterials)
        {
            var check = await _context.RecipeDetails
                .AnyAsync(x => x.IdRecipe == idRecipe && x.IdMaterials == idMaterials);
            if (check)
            {
                return new ApiErrorResult<bool>("Dữ liệu đã tồn tại");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<GetCreateRecipe>> Update(UpdateRecipe bundle)
        {
            var data = await _context.Recipes.FindAsync(bundle.IdRecipe);

            data.IdProduct = bundle.IdProduct;
            data.Name = bundle.Name;
            data.Note = bundle.Note;

            _context.Recipes.Update(data);

            // thêm nguyên liệu
            if (bundle.IdMaterials != null)
            {
                int i = 0;
                foreach (int item in bundle.IdMaterials)
                {
                    var recipeDetail = new RecipeDetail()
                    {
                        IdMaterials = item,
                        Amount = bundle.Amount[i],
                        Unit = bundle.Unit[i],
                        IdRecipe = data.Id
                    };

                    _context.RecipeDetails.Add(recipeDetail);

                    i++;
                }
            }

            await _context.SaveChangesAsync();

            var result = new GetCreateRecipe()
            {
                IdProduct = data.IdProduct,
                NameRecipe = data.Name,
                Prioritize = data.Prioritize
            };
            return new ApiSuccessResult<GetCreateRecipe>(result);
        }
    }
}