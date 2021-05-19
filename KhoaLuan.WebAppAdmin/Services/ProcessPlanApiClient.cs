using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessPlan;
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
    public class ProcessPlanApiClient : BaseApiClient, IProcessPlanApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProcessPlanApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GetAllProductGroup>> GetAllProductGroup()
        {
            var url = $"/api/ProcessPlan/product-group";
            var result = await GetAll<GetAllProductGroup>(url);
            return result;
        }

        public async Task<List<GetAllProductRecipes>> GetAllProductRecipes(int id, string key)
        {
            var url = $"/api/ProcessPlan/product-recipes/{id}/{key}";
            var result = await GetAll<GetAllProductRecipes>(url);
            return result;
        }

        public async Task<List<GetAllProductType>> GetAllProductType(int id)
        {
            var url = $"/api/ProcessPlan/product-type/{id}";
            var result = await GetAll<GetAllProductType>(url);
            return result;
        }

        public async Task<List<GetEmployee>> GetEmployee(string key)
        {
            var url = $"/api/OrderPlan/employee?key={key}";
            var result = await GetAll<GetEmployee>(url);
            return result;
        }

        public async Task<List<GetListPacksById>> GetListPacksById(int id)
        {
            var url = $"/api/ProcessPlan/pack/{id}";
            var result = await GetAll<GetListPacksById>(url);
            return result;
        }

        public async Task<List<GetListPacksProduct>> GetListPacksProduct(int id)
        {
            var url = $"/api/ProcessPlan/pack-product/{id}";
            var result = await GetAll<GetListPacksProduct>(url);
            return result;
        }

        public async Task<ApiResult<bool>> Create(CreatePlan bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProcessPlan";
            var result = await Create<bool>(url, httpContent);
            return result;
        }

        public async Task<List<GetByProcessPlanCensorship>> GetByProcessPlanCensorship()
        {
            var url = $"/api/ProcessPlan/censorship";
            var result = await GetAll<GetByProcessPlanCensorship>(url);
            return result;
        }

        public async Task<ApiResult<GetProcessPlanById>> GetProcessPlanById(long id)
        {
            var url = $"/api/ProcessPlan/process-plan-id/{id}";
            var result = await GetIdAsync<GetProcessPlanById>(url);
            return result;
        }

        public async Task<ApiResult<GetProcessPlanById>> Update(UpdatePlan bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProcessPlan/";
            var result = await Update<GetProcessPlanById>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await Delete($"/api/ProcessPlan/" + id);
            return result;
        }

        public async Task<ApiResult<PagedResult<ProcessPlanVm>>> GetProcessPlanPaging(GetProcessPlanPagingRequest bundle)
        {
            var url = $"/api/ProcessPlan/paging?pageIndex=" +
             $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}&status={bundle.Status}";
            var result = await GetListAsync<ProcessPlanVm>(url);
            return result;
        }

        public async Task<ApiResult<GetProcessPlanByIdRecipes>> GetProcessPlanByIdRecipes(long id)
        {
            var url = $"/api/ProcessPlan/process-plan-id-recipes/{id}";
            var result = await GetIdAsync<GetProcessPlanByIdRecipes>(url);
            return result;
        }

        public async Task<List<GetByProcessPlanCensorship>> GetByProcessPlanApproved(string key)
        {
            var url = $"/api/ProcessPlan/approved/{key}";
            var result = await GetAll<GetByProcessPlanCensorship>(url);
            return result;
        }

        public async Task<List<GetMaterialsByRecipes>> GetMaterialsByRecipes(int idRecipe)
        {
            var url = $"/api/ProcessPlan/materials-recipe/{idRecipe}";
            var result = await GetAll<GetMaterialsByRecipes>(url);
            return result;
        }

        public async Task<ApiResult<bool>> UpdateProcessPlanCensorship(UpdateCensorship bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProcessPlan/censorship";
            var result = await Update<bool>(url, httpContent);
            return result;
        }
    }
}