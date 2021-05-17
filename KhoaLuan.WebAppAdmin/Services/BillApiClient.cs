using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Bill;
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
    public class BillApiClient : BaseApiClient, IBillApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BillApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<GetAllSuppliersBill>> GetAllSuppliers(string key)
        {
            var url = $"/api/Bill/suppliers/{key}";
            var result = await GetAll<GetAllSuppliersBill>(url);
            return result;
        }

        public async Task<List<GetAllPaymentStautsBill>> GetAllUnpaidBill(string key)
        {
            var url = $"/api/Bill/unpaid-bill?key={key}";
            var result = await GetAll<GetAllPaymentStautsBill>(url);
            return result;
        }

        public async Task<ApiResult<PagedResult<GetAllPaymentStautsBill>>> GetAllPaidBill(GetAllPaidBillPanning bundle)
        {
            var url = $"/api/Bill/paging?pageIndex=" +
         $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}";
            var result = await GetListAsync<GetAllPaymentStautsBill>(url);
            return result;
        }

        public async Task<List<GetByIdOrderPlanBills>> GetByIdOrderPlanBills(long id)
        {
            var url = $"/api/Bill/order-plan/{id}";
            var result = await GetAll<GetByIdOrderPlanBills>(url);
            return result;
        }

        public async Task<List<GetByOrderPlanBills>> GetByOrderPlanBills(string key)
        {
            var url = $"/api/Bill/order-plan/all?key={key}";
            var result = await GetAll<GetByOrderPlanBills>(url);
            return result;
        }

        public async Task<ApiResult<GetBillById>> Create(CreateBill bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Bill";
            var result = await Create<GetBillById>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<GetBillById>> GetBillById(long id)
        {
            var url = $"/api/Bill/id-bill/{id}";
            var result = await GetIdAsync<GetBillById>(url);
            return result;
        }

        public async Task<ApiResult<ReturnUpdate>> Update(UpdateBill bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Bill";
            var result = await Update<ReturnUpdate>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await Delete($"/api/Bill/" + id);
            return result;
        }

        public async Task<ApiResult<bool>> UpdateUnpaid(UpdateUnpaid bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Bill/unpaid";
            var result = await Update(url, httpContent);
            return result;
        }
    }
}