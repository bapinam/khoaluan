﻿using KhoaLuan.ApiClient.Common;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.OrderPlan;
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

        public async Task<ApiResult<bool>> Create(CreateOrderPlan bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/OrderPlan";
            var result = await Create<bool>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await Delete($"/api/OrderPlan/" + id);
            return result;
        }

        public async Task<List<GetByOrderPlan>> GetByOrderPlanCensorship()
        {
            var url = $"/api/OrderPlan/censorship";
            var result = await GetAll<GetByOrderPlan>(url);
            return result;
        }

        public async Task<List<GetEmployee>> GetEmployee(string key)
        {
            var url = $"/api/OrderPlan/employee?key={key}";
            var result = await GetAll<GetEmployee>(url);
            return result;
        }

        public async Task<List<GetListSuppliersPlan>> GetListSuppliersPlan(string key)
        {
            var url = $"/api/OrderPlan/list-suppliers?key={key}";
            var result = await GetAll<GetListSuppliersPlan>(url);
            return result;
        }

        public async Task<List<GetMaterialsPlan>> GetMaterialsSearch(int id, string key)
        {
            var url = $"/api/OrderPlan/materials?id={id}&key={key}";
            var result = await GetAll<GetMaterialsPlan>(url);
            return result;
        }

        public async Task<List<GetMaterialsTypePlan>> GetMaterialsType(GroupType group)
        {
            var url = $"/api/OrderPlan/materials-type?group=" + $"{group}";
            var result = await GetAll<GetMaterialsTypePlan>(url);
            return result;
        }

        public async Task<ApiResult<bool>> UpdateOrderPlanCensorship(UpdateOrderPlanCensorship bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/OrderPlan/update-censorship";
            var result = await Update(url, httpContent);
            return result;
        }
    }
}