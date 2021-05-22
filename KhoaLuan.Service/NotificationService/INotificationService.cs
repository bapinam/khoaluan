using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.NotificationService
{
    public interface INotificationService
    {
        Task<ApiResult<bool>> Create(CreateNotification bundle);

        Task<List<GetNotification>> GetFiveNotifications(string name);

        Task<ApiResult<PagedResult<GetNotification>>> GetAllNotifications(GetNotificationPagingRequest bundle);

        Task<ApiResult<bool>> Delete(long id);

        Task<ApiResult<bool>> DeleteAll(string name);

        Task<ApiResult<bool>> Update(UpdateView bundle);
    }
}