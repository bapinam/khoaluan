using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Notification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly EnterpriseDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public NotificationService(EnterpriseDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApiResult<bool>> Create(CreateNotification bundle)
        {
            var idRece = await _userManager.FindByNameAsync(bundle.NameReceiver);
            var notification = new Notification()
            {
                IdReceiver = idRece.Id,
                Name = bundle.Name,
                Path = bundle.Path,
                Time = bundle.Time,
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetNotification>> GetFiveNotifications(string name)
        {
            var idrece = await _userManager.FindByNameAsync(name);
            var notification = _context.Notifications.Include(x => x.Receiver)
                .Where(x => x.IdReceiver == idrece.Id);
            var count = await notification.CountAsync();
            var result = await notification.OrderByDescending(x => x.View)
                .Take(5).Select(x => new GetNotification
                {
                    Id = x.Id,
                    IdReceiver = x.IdReceiver,
                    NameReceiver = x.Receiver.UserName,
                    Name = x.Name,
                    Path = x.Path,
                    Time = (DateTime.Now - x.Time).Days,
                    Count = count,
                }).ToListAsync();

            return new List<GetNotification>(result);
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return new ApiErrorResult<bool>("Không tồn tại thông báo");
            }
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<GetNotification>>>
            GetAllNotifications(GetNotificationPagingRequest bundle)
        {
            var idrece = await _userManager.FindByNameAsync(bundle.Name);
            var notification = _context.Notifications.Include(x => x.Receiver)
            .Where(x => x.IdReceiver == idrece.Id);

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                notification = notification.Where(c => c.Name.Contains(bundle.Keyword));
            }
            var totalRow = await notification.CountAsync();
            var result = await notification.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .OrderByDescending(x => x.View)
                .Select(x => new GetNotification
                {
                    Id = x.Id,
                    IdReceiver = x.IdReceiver,
                    NameReceiver = x.Receiver.UserName,
                    Name = x.Name,
                    Path = x.Path,
                    Time = (DateTime.Now - x.Time).Days,
                    Count = totalRow,
                }).ToListAsync();
            var pagedResult = new PagedResult<GetNotification>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = result
            };
            return new ApiSuccessResult<PagedResult<GetNotification>>(pagedResult);
        }
    }
}