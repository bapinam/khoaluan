using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.MaterialsType;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
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
    public class MaterialsTypeApiClient : BaseApiClient, IMaterialsTypeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MaterialsTypeApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<GetByIdListMaterialsType>> Create(CreateMaterialsType bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/MaterialsType";
            var result = await Create<GetByIdListMaterialsType>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var result = await Delete($"/api/MaterialsType/" + id);
            return result;
        }

        public async Task<List<GetAllMaterialsType>> GetAll()
        {
            var url = $"/api/MaterialsType/get-all";
            var result = await GetAll<GetAllMaterialsType>(url);
            return result;
        }

        public async Task<ApiResult<GetByIdListMaterialsType>> GetById(int id)
        {
            var url = $"/api/MaterialsType/" + $"{id}";
            var result = await GetIdAsync<GetByIdListMaterialsType>(url);
            return result;
        }

        public async Task<ApiResult<PagedResult<MaterialsTypeViewModel>>>
            GetUsersPaging(GetMaterialsTypePagingRequest bundle)
        {
            var url = $"/api/MaterialsType/paging?pageIndex=" +
                $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}";
            var result = await GetListAsync<MaterialsTypeViewModel>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            var url = $"/api/MaterialsType/check-name?name=" + $"{name}&id={id}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<ApiResult<bool>> Update(int id, UpdateMaterialsType bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/MaterialsType/" + $"{id}";
            var result = await Update(url, httpContent);
            return result;
        }
    }
}