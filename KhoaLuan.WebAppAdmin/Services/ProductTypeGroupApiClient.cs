using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProductTypeGroup;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public class ProductTypeGroupApiClient : BaseApiClient, IProductTypeGroupApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductTypeGroupApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<GetByIdListProductTypeGroup>> Create(CreateProductTypeGroup bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProductTypeGroup";
            var result = await Create<GetByIdListProductTypeGroup>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var result = await Delete($"/api/ProductTypeGroup/" + id);
            return result;
        }

        public async Task<ApiResult<GetByIdListProductTypeGroup>> GetById(int id)
        {
            var url = $"/api/ProductTypeGroup/" + $"{id}";
            var result = await GetIdAsync<GetByIdListProductTypeGroup>(url);
            return result;
        }

        public async Task<ApiResult<PagedResult<ProductTypeGroupViewModel>>> GetUsersPaging(GetProductTypeGroupPagingRequest bundle)
        {
            var url = $"/api/ProductTypeGroup/paging?pageIndex=" +
                $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}";
            var result = await GetListAsync<ProductTypeGroupViewModel>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            var url = $"/api/ProductTypeGroup/check-name?name=" + $"{name}&id={id}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<ApiResult<bool>> Update(int id, UpdateProductTypeGroup bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProductTypeGroup/" + $"{id}";
            var result = await Update(url, httpContent);
            return result;
        }

        public async Task<List<GetAllProductTypeGroup>> GetAll()
        {
            var url = $"/api/ProductTypeGroup/get-all";
            var result = await GetAll<GetAllProductTypeGroup>(url);
            return result;
        }
    }
}