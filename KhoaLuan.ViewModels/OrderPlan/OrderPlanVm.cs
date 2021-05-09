using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.OrderPlan
{
    public class OrderPlanVm
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { set; get; }
        public string CreatedDate { get; set; }
        public string CodeCreator { get; set; }
        public string CodeResponsible { get; set; }
    }
}