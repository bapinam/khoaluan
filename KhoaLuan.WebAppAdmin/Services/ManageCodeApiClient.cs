using KhoaLuan.ApiClient.Common;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.CodeManage;
using KhoaLuan.ViewModels.Common;
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
    public class ManageCodeApiClient : BaseApiClient, IManageCodeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ManageCodeApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> Create(CreateCode bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ManageCode";
            var result = await Create<bool>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var result = await Delete($"/api/ManageCode/" + id);
            return result;
        }

        public async Task<List<GetAllCode>> GetAll(CodeType type)
        {
            var url = $"/api/ManageCode/get-all?type={type}";
            var result = await GetAll<GetAllCode>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            var url = $"/api/ManageCode/check-name?name=" + $"{name}&id={id}";
            var result = await iCheck(url);
            return result;
        }

        public async Task<ApiResult<bool>> Update(UpdateCode bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ManageCode";
            var result = await Update(url, httpContent);
            return result;
        }
    }
}