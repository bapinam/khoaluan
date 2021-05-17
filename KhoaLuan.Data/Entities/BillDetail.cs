using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class BillDetail
    {
        public long Id { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Discount { get; set; }

        public int IdMaterials { get; set; }
        public long IdBill { get; set; }
        public Bill Bill { get; set; }
        public Material Material { get; set; }
    }
}