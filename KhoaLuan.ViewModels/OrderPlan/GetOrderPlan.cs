using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.OrderPlan
{
    public class GetOrderPlan
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Duration { set; get; }
        public string DateMan { get; set; }
        public string ExpectedDate { get; set; }
        public string Note { get; set; }
        public Guid IdResponsible { get; set; }
        public string CodeResponsible { get; set; }
        public string NameResponsible { get; set; }
    }
}