using KhoaLuan.ViewModels.Notification;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationApiClient _notificationApiClient;

        public NotificationsController(INotificationApiClient notificationApiClient)
        {
            _notificationApiClient = notificationApiClient;
        }

        public async Task<IActionResult> Index(string name, string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetNotificationPagingRequest()
            {
                Name = name,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _notificationApiClient.GetAllNotifications(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetFiveNotifications(string name)
        {
            var result = await _notificationApiClient.GetFiveNotifications(name);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNotification bundle)
        {
            var result = await _notificationApiClient.Create(bundle);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _notificationApiClient.Delete(id);
            return Ok(result);
        }
    }
}