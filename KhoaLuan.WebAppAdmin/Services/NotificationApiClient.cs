using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Notification;
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
    public class NotificationApiClient : BaseApiClient, INotificationApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> Create(CreateNotification bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Notification";
            var result = await Create<bool>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var result = await Delete($"/api/Notification/" + id);
            return result;
        }

        public async Task<ApiResult<bool>> DeleteAll(string name)
        {
            var result = await Delete($"/api/Notification/all/" + name);
            return result;
        }

        public async Task<ApiResult<bool>> Update(UpdateView bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Notification/";
            var result = await Update(url, httpContent);
            return result;
        }

        public async Task<ApiResult<PagedResult<GetNotification>>>
            GetAllNotifications(GetNotificationPagingRequest bundle)
        {
            var url = $"/api/Notification/paging?pageIndex=" +
              $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}&name={bundle.Name}";
            var result = await GetListAsync<GetNotification>(url);
            return result;
        }

        public async Task<List<GetNotification>> GetFiveNotifications(string name)
        {
            var url = $"/api/Notification/five/{name}";
            var result = await GetAll<GetNotification>(url);
            return result;
        }
    }
}