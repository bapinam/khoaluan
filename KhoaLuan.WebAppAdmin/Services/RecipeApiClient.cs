using KhoaLuan.ApiClient.Common;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Recipe;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public class RecipeApiClient : BaseApiClient, IRecipeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecipeApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<PagedResult<ProductRecipe>>> GetRecipePaging(GetRecipePagingRequest bundle)
        {
            var url = $"/api/Recipe/paging?pageIndex=" +
                $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}&productType={bundle.ProductType}";
            var result = await GetListAsync<ProductRecipe>(url);
            return result;
        }

        public async Task<List<GetListRecipe>> GetListRecipe(int id)
        {
            var url = $"/api/recipe/" + $"{id}";
            var result = await GetAll<GetListRecipe>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iName(string name, int idSP, int? id)
        {
            var url = $"/api/Recipe/check-name?name=" + $"{name}&idSP={idSP}&id={id}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<List<GetMaterialsType>> GetMaterialsType(GroupType? group)
        {
            var url = $"/api/Recipe/materials-type?group=" + $"{group}";
            var result = await GetAll<GetMaterialsType>(url);
            return result;
        }

        public async Task<List<GetListMaterials>> GetListMaterials(ListBundleMaterials bundle)
        {
            var url = $"/api/Recipe/materials?groupTypeMaterials=" + $"{bundle.GroupTypeMaterials}" +
                $"&materialsType={bundle.MaterialsType}&keyWordNL={bundle.KeyWordNL}";
            var result = await GetAll<GetListMaterials>(url);
            return result;
        }

        public async Task<List<GetListPacksProduct>> GetListPacks(int id)
        {
            var url = $"/api/recipe/packs/" + $"{id}";
            var result = await GetAll<GetListPacksProduct>(url);
            return result;
        }

        public async Task<ApiResult<GetCreateRecipe>> CreateRecipe(CreateRecipe bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/recipe";
            var result = await Create<GetCreateRecipe>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<string>> UpdatePrioritizeRecipe(UpdatePrioritizeRecipe bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/recipe/prioritize";
            var result = await Update<string>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<string>> Delete(int id, int idPorduct)
        {
            var result = await Delete<string>($"/api/recipe/{id}/{idPorduct}");
            return result;
        }

        public async Task<ApiResult<GetListIdRecipe>> GetListIdRecipe(int id)
        {
            var url = $"/api/recipe/recipe/" + $"{id}";
            var result = await GetIdAsync<GetListIdRecipe>(url);
            return result;
        }

        public async Task<ApiResult<bool>> DeleteMaterials(long id)
        {
            var result = await Delete($"/api/recipe/materials/{id}");
            return result;
        }

        public async Task<ApiResult<bool>> iMaterials(int idRecipe, int idMaterials)
        {
            var url = $"/api/Recipe/check-materials?idRecipe=" + $"{idRecipe}&idMaterials={idMaterials}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<ApiResult<GetCreateRecipe>> Update(UpdateRecipe bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/recipe";
            var result = await Update<GetCreateRecipe>(url, httpContent);
            return result;
        }
    }
}