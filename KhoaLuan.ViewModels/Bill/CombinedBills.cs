using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class CombinedBills
    {
        public long[] Combined { get; set; }
        public string Code { get; set; }
        public string NameCreator { get; set; }
        public Guid IdResponsible { get; set; }
    }
}