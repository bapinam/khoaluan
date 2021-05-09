using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.OrderPlan
{
    public class GetByOrderPlan
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Order { get; set; }
        public bool Censorship { get; set; }
        public string Status { set; get; }
        public bool Duration { set; get; }
        public string CreatedDate { get; set; }
        public string ExpectedDate { get; set; }
        public string Note { get; set; }
        public Guid IdCreator { get; set; }
        public string CodeCreator { get; set; }
        public Guid IdResponsible { get; set; }
        public string CodeResponsible { get; set; }
        public string NameResponsible { get; set; }
        public string CodeAuthority { get; set; }
        public List<ListOrderDetails> ListOrderDetails { get; set; }

        public int Count { get; set; }
    }
}