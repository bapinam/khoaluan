using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class GetByIdOrderPlanBills
    {
        public long IdOrderDetail { get; set; }
        public int IdMaterials { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int EnterAmount { get; set; }
        public string Unit { get; set; }
        public int Count { get; set; }
    }
}