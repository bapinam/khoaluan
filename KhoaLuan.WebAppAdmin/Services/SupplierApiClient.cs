using KhoaLuan.ApiClient;
using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Supplier;
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
    public class SupplierApiClient : BaseApiClient, ISupplierApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SupplierApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<GetByIdListSupplier>> Create(SupplierCreate bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/supplier";
            var result = await Create<GetByIdListSupplier>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var result = await Delete($"/api/supplier/" + id);
            return result;
        }

        public async Task<ApiResult<GetByIdListSupplier>> GetById(int id)
        {
            var url = $"/api/supplier/" + $"{id}";
            var result = await GetIdAsync<GetByIdListSupplier>(url);
            return result;
        }

        public async Task<ApiResult<PagedResult<SupplierVm>>> GetUsersPaging(GetSupplierPagingRequest bundle)
        {
            var url = $"/api/supplier/paging?pageIndex=" +
                $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}";
            var result = await GetListAsync<SupplierVm>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iEmail(string email, int? id)
        {
            var url = $"/api/supplier/check-email?email=" + $"{email}&id={id}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<ApiResult<bool>> iTax(string tax, int? id)
        {
            var url = $"/api/supplier/check-tax?tax=" + $"{tax}&id={id}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<ApiResult<bool>> Update(int id, SupplierUpdate bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/supplier/" + $"{id}";
            var result = await Update(url, httpContent);
            return result;
        }
    }
}