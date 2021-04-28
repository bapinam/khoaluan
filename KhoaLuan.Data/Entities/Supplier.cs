using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Tax { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Bill> Bills { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}