using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class GetByOrderPlanBills
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public int Distance { get; set; }
        public string CodeResponsible { get; set; }
        public int Count { get; set; }
    }
}