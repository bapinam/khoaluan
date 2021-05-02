using KhoaLuan.ApiClient.Common;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.OrderPlan;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public class OrderPlanApiClient : BaseApiClient, IOrderPlanApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderPlanApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GetMaterialsTypePlan>> GetMaterialsType(GroupType group)
        {
            var url = $"/api/OrderPlan/materials-type?group=" + $"{group}";
            var result = await GetAll<GetMaterialsTypePlan>(url);
            return result;
        }
    }
}