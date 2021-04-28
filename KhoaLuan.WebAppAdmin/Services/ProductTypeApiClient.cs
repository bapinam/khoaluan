using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProductType;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public class ProductTypeApiClient : BaseApiClient, IProductTypeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductTypeApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<GetByIdListProductType>> Create(CreateProductType bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProductType";
            var result = await Create<GetByIdListProductType>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var result = await Delete($"/api/ProductType/" + id);
            return result;
        }

        public async Task<ApiResult<GetByIdListProductType>> GetById(int id)
        {
            var url = $"/api/ProductType/" + $"{id}";
            var result = await GetIdAsync<GetByIdListProductType>(url);
            return result;
        }

        public async Task<ApiResult<PagedResult<ProductTypeViewModel>>> GetUsersPaging(GetProductTypePagingRequest bundle)
        {
            var url = $"/api/ProductType/paging?pageIndex=" +
                $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}&grouptype={bundle.GroupType}";
            var result = await GetListAsync<ProductTypeViewModel>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            var url = $"/api/ProductType/check-name?name=" + $"{name}&id={id}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<ApiResult<bool>> Update(int id, UpdateProductType bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProductType/" + $"{id}";
            var result = await Update(url, httpContent);
            return result;
        }

        public async Task<List<GetAllProductType>> GetAll()
        {
            var url = $"/api/ProductType/get-all";
            var result = await GetAll<GetAllProductType>(url);
            return result;
        }
    }
}