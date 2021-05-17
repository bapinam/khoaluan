using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class OrderDetail
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public int EnterAmount { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }

        public int? IdSupplier { get; set; }
        public long IdOrderPlan { get; set; }
        public int IdMaterials { get; set; }
        public Supplier Supplier { get; set; }
        public OrderPlan OrderPlan { get; set; }
        public Material Material { get; set; }
    }
}