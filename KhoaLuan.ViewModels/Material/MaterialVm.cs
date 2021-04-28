using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KhoaLuan.ViewModels.Material
{
    public class MaterialVm
    {
        public int Id { get; set; }

        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Tên nguyên vật liệu")]
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

        [Display(Name = "Tên nguyên vật liệu")]
        public string NameMaterialType { get; set; }

    }
}