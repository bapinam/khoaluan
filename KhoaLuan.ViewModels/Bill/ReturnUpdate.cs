using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class ReturnUpdate
    {
        public bool StatusOrder { set; get; }
        public bool PaymentStatus { set; get; }

        public long Id { get; set; }
        public string CodeBill { get; set; }
    }
}