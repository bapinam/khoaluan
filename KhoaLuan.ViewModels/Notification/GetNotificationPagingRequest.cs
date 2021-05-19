using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Notification
{
    public class GetNotificationPagingRequest : PagingRequestBase
    {
        public string Name { get; set; }
        public string Keyword { get; set; }
    }
}