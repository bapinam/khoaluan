using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KhoaLuan.ViewModels.Product
{
    public class GetByIdListProduct
    {
        public int Id { get; set; }

        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [Display(Name = "Số lượng")]
        public long Amount { get; set; }

        [Display(Name = "Phần trăm")]
        public int AmountPercent { get; set; }

        [Display(Name = "Nhắc nhở")]
        public bool Reminder { get; set; }

        [Display(Name = "Tên đóng gói mặc định")]
        public string NamePackDefault { get; set; }

        [Display(Name = "Tên loại sản phẩm")]
        public string NameProductType { get; set; }
    }
}