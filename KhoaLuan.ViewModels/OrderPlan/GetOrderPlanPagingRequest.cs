using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.OrderPlan
{
    public class GetOrderPlanPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string Status { get; set; }
    }
}