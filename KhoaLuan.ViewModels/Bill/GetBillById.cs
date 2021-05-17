using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class GetBillById
    {
        public long Id { get; set; }
        public string CodeBill { get; set; }
        public string StorageCode { get; set; }
        public string PurchaseDate { get; set; }
        public string PurchaseDateDefault { get; set; }
        public string CreatedDate { get; set; }
        public int? Tax { get; set; }
        public string PaymentStatus { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TotalMoney { get; set; }
        public string ConvertNumbers { get; set; }

        public long IdPlan { get; set; }
        public int IdSupplier { get; set; }
        public string CodeSupplier { get; set; }
        public string CodePlan { get; set; }
        public string CodeCreator { get; set; }

        public List<ListBillDetail> ListBillDetails { get; set; }

        public List<ListBillDetail> ListBillDetailNotIds { get; set; }
    }

    public class ListBillDetail
    {
        public long IdBillDetail { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public int AmountOrder { get; set; }
        public int EnterAmountOrder { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string CodeMaterials { get; set; }
        public string NameMaterials { get; set; }
        public int IdMaterials { get; set; }
    }
}