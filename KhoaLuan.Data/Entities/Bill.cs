using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class Bill
    {
        public long Id { get; set; }
        public string CodeBill { get; set; }
        public string StorageCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Tax { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal AmountPaid { get; set; }
        public string Images { get; set; }

        public int IdSupplier { get; set; }
        public long IdPlan { get; set; }
        public OrderPlan OrderPlan { get; set; }
        public Supplier Supplier { get; set; }
        public List<BillDetail> BillDetails { get; set; }
        public AppUser Creator { get; set; }
        public Guid IdCreator { get; set; }
    }
}