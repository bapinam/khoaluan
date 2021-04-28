using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class OrderPlan
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Order { get; set; }
        public bool Censorship { get; set; }
        public bool Status { set; get; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Note { get; set; }

        public List<Bill> Bills { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public AppUser Creator { get; set; }
        public Guid IdCreator { get; set; }
        public AppUser Responsible { get; set; }
        public Guid IdResponsible { get; set; }
    }
}