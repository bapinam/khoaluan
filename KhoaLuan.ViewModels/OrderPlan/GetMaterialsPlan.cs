using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.OrderPlan
{
    public class GetMaterialsPlan
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Amount { get; set; }
        public string Image { get; set; }
        public long? Max { get; set; }
    }
}