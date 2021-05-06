using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.OrderPlan
{
    public class UpdateOrderPlanCensorship
    {
        public long Id { get; set; }
        public long[] IdOrderDetail { get; set; }
        public int[] IdSupplier { get; set; }
        public string[] Price { get; set; }
    }
}