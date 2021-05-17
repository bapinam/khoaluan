using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class CreateBill
    {
        public long IdOrderPlan { get; set; }
        public string StorageCode { get; set; }
        public string CodeBill { get; set; }
        public int IdSupliers { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Tax { get; set; }
        public string NameCreator { get; set; }
        public string AmountPaid { get; set; }

        public long[] IdOrderDetail { get; set; }
        public int[] IdMaterials { get; set; }
        public int[] Amount { get; set; }
        public int[] EnterAmount { get; set; }
        public int[] Discount { get; set; }
        public string[] Unit { get; set; }
        public double[] Price { get; set; }
    }
}