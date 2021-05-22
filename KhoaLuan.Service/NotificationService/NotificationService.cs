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
                Time = DateTime.Now,
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        // khi lam gi do thi reload lai cai notification nay ? ddusng roi anh,hihi ..o
        public async Task<List<GetNotification>> GetFiveNotifications(string name)
        {
            //var idrece = await _userManager.FindByNameAsync(name);
            //var notification = _context.Notifications.Include(x => x.Receiver)
            //    .Where(x => x.IdReceiver == idrece.Id);

            var notifications = await _context.Notifications.Include(x => x.Receiver)
                .Where(x => x.Receiver.UserName == name).OrderBy(x => x.View).ToListAsync();

            if (notifications.Count == 0)
                return new List<GetNotification>();

            // var whereCount = notification;
            var count = notifications.Count(x => !x.View);

            var result = notifications.Take(5).Select(x => new GetNotification
            {
                Id = x.Id,
                IdReceiver = x.IdReceiver,
                NameReceiver = x.Receiver.UserName,
                Name = x.Name,
                Path = x.Path,
                Time = (DateTime.Now - x.Time).Days,
                Count = count,
                View = x.View ? "Đã xem" : "Chưa xem"
            });

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

        public async Task<ApiResult<bool>> DeleteAll(string name)
        {
            var idrece = await _userManager.FindByNameAsync(name);

            var notification = await _context.Notifications
                .Where(x => x.IdReceiver == idrece.Id && x.View == true).ToListAsync();
            if (notification == null)
            {
                return new ApiErrorResult<bool>("Không tồn tại thông báo đã xem");
            }

            _context.Notifications.RemoveRange(notification);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(UpdateView bundle)
        {
            var notification = await _context.Notifications.FindAsync(bundle.Id);
            if (notification == null)
            {
                return new ApiErrorResult<bool>("Không tồn tại thông báo");
            }

            notification.View = true;
            _context.Notifications.Update(notification);
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
                notification = notification.Where(c => c.Name.Contains(bundle.Keyword.Trim()));
            }

            var countNotifi = notification;
            var totalRow = await countNotifi.CountAsync();
            var result = await notification.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .OrderBy(x => x.View)
                .Select(x => new GetNotification
                {
                    Id = x.Id,
                    IdReceiver = x.IdReceiver,
                    NameReceiver = x.Receiver.UserName,
                    Name = x.Name,
                    Path = x.Path,
                    Time = (DateTime.Now - x.Time).Days,
                    Count = totalRow,
                    View = x.View == true ? "Đã xem" : "Chưa xem"
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