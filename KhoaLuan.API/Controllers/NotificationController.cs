using KhoaLuan.Service.NotificationService;
using KhoaLuan.ViewModels.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllNotifications([FromQuery] GetNotificationPagingRequest bundle)
        {
            var result = await _notificationService.GetAllNotifications(bundle);
            return Ok(result);
        }

        [HttpGet("five/{name}")]
        public async Task<IActionResult> GetFiveNotifications(string name)
        {
            var result = await _notificationService.GetFiveNotifications(name);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotification bundle)
        {
            var result = await _notificationService.Create(bundle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _notificationService.Delete(id);
            return Ok(result);
        }
    }
}