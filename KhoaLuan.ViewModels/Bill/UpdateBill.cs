using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class UpdateBill
    {
        public long IdBill { get; set; }
        public string StorageCode { get; set; }
        public string CodeBill { get; set; }
        public int IdSupliers { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Tax { get; set; }
        public string AmountPaid { get; set; }

        // cập nhật
        public double[] Price { get; set; }

        public int[] IdMaterials { get; set; }
        public int[] Discount { get; set; }
        public int[] EnterAmount { get; set; }

        //// tạo
        public double[] PriceCreate { get; set; }

        public int[] IdMaterialsCreate { get; set; }
        public int[] DiscountCreate { get; set; }
        public int[] EnterAmountCreate { get; set; }
        public string[] UnitCreate { get; set; }
    }
}