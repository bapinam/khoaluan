using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class GetAllPaymentStautsBill
    {
        public long Id { get; set; }
        public string CodeBill { get; set; }
        public string StorageCode { get; set; }
        public string CreatedDate { get; set; }
        public int Count { get; set; }
        public decimal PaymentMoeny { get; set; }
        public decimal TotalMoney { get; set; }
        public string CodePlan { get; set; }
        public string CodeCreator { get; set; }
    }
}