using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Entities
{
    public class ProcessingVoucherDetail
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public int IdRecipe { get; set; }
        public Recipe Recipe { get; set; }

        public long IdVoucher { get; set; }
        public ProcessingVoucher ProcessingVoucher { get; set; }
    }
}