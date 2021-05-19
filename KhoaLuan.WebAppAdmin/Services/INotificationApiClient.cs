﻿using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface INotificationApiClient
    {
        Task<ApiResult<bool>> Create(CreateNotification bundle);

        Task<List<GetNotification>> GetFiveNotifications(string name);

        Task<ApiResult<PagedResult<GetNotification>>> GetAllNotifications(GetNotificationPagingRequest bundle);

        Task<ApiResult<bool>> Delete(long id);
    }
}