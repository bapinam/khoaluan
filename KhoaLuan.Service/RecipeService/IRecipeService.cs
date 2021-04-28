using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Recipe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhoaLuan.Service.RecipeService
{
    public interface IRecipeService
    {
        Task<ApiResult<PagedResult<ProductRecipe>>> GetRecipePaging(GetRecipePagingRequest bundle);

        Task<ApiResult<GetListIdRecipe>> GetListIdRecipe(int id);

        Task<List<GetListRecipe>> GetListRecipe(int id);

        Task<ApiResult<bool>> iName(string name, int idSP, int? id);

        Task<ApiResult<bool>> iMaterials(int idRecipe, int idMaterials);

        Task<List<GetMaterialsType>> GetMaterialsType(GroupType? group);

        Task<List<GetListMaterials>> GetListMaterials(ListBundleMaterials bundle);

        Task<List<GetListPacks>> GetListPacks(int id);

        Task<ApiResult<GetCreateRecipe>> Create(CreateRecipe bundle);

        Task<ApiResult<string>> UpdatePrioritizeRecipe(UpdatePrioritizeRecipe bundle);

        Task<ApiResult<GetCreateRecipe>> Update(UpdateRecipe bundle);

        Task<ApiResult<string>> Delete(int id, int idProuduct);

        Task<ApiResult<bool>> DeleteMaterials(long id);
    }
}