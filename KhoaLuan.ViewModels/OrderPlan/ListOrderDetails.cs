using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.OrderPlan
{
    public class ListOrderDetails
    {
        public long IdOrderDetail { get; set; }
        public string CodeMaterials { get; set; }
        public string NameMaterials { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public string CodeSuppliers { get; set; }
        public decimal Price { get; set; }
    }
}