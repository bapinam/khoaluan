﻿using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessingDetail;
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
    public class ProcessingDetailApiClient : BaseApiClient, IProcessingDetailApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProcessingDetailApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> CancelProcess(long id)
        {
            var url = $"/api/ProcessingDetail/cance-process/{id}";
            var result = await GetIdAsync<bool>(url);
            return result;
        }

        public async Task<ApiResult<bool>> ChangeMarkStatus(long id)
        {
            var url = $"/api/ProcessingDetail/change-mark/{id}";
            var result = await GetIdAsync<bool>(url);
            return result;
        }

        public async Task<ApiResult<bool>> Create(CreateProcess bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/ProcessingDetail";
            var result = await Create<bool>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await Delete($"/api/ProcessingDetail/" + id);
            return result;
        }

        public async Task<List<ProcessingDetailVm>> GetAllProcessDetailById(long id)
        {
            var url = $"/api/ProcessingDetail/process-detail-by/{id}";
            var result = await GetAll<ProcessingDetailVm>(url);
            return result;
        }

        public async Task<ApiResult<ProcessingPlanVmCount>> GetDistributing(string key)
        {
            var url = $"/api/ProcessingDetail/distributing?key={key}";
            var result = await GetIdAsync<ProcessingPlanVmCount>(url);
            return result;
        }

        public async Task<ApiResult<ListProcessingVoucher>> GetMarkProcessing(string key)
        {
            var url = $"/api/ProcessingDetail/mark?key={key}";
            var result = await GetIdAsync<ListProcessingVoucher>(url);
            return result;
        }

        public async Task<ApiResult<PagedResult<ProcessingVoucherVm>>> GetProcessComplete(GetProcessCompletePaging bundle)
        {
            var url = $"/api/ProcessingDetail/paging?pageIndex=" +
                      $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}";
            var result = await GetListAsync<ProcessingVoucherVm>(url);
            return result;
        }

        public async Task<ApiResult<GetViewProcessingVocher>> GetViewProcessingVocher(long id)
        {
            var url = $"/api/ProcessingDetail/view-vocher/{id}";
            var result = await GetIdAsync<GetViewProcessingVocher>(url);
            return result;
        }

        public async Task<ApiResult<bool>> SplitProcess(long id)
        {
            var url = $"/api/ProcessingDetail/split-process/{id}";
            var result = await GetIdAsync<bool>(url);
            return result;
        }
    }
}