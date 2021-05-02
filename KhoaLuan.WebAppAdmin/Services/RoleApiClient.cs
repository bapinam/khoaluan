using KhoaLuan.ApiClient.Common;
using KhoaLuan.Data.Enums;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Decentralization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.WebAppAdmin.Services
{
    [Authorize(Roles = ListRole.Admin)]
    public class RoleApiClient : BaseApiClient, IRoleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> Assign(AssignVm bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Role/assign";
            var result = await Create<bool>(url, httpContent);
            return result;
        }

        public async Task<List<string>> GetRole(Guid id)
        {
            var url = $"/api/Role/{id}";
            var result = await GetAll<string>(url);
            return result;
        }
    }
}