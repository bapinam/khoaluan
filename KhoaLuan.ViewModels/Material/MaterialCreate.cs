using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace KhoaLuan.ViewModels.Material
{
    public class MaterialCreate
    {
        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Tên nguyên vật liệu")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Mức tồn tối thiểu")]
        public long? Min { get; set; }

        [Display(Name = "Mức tồn tối đa")]
        public long? Max { get; set; }

        [Display(Name = "Ngày bắt đầu nhắc nhở")]
        public DateTime? ReminderStartDate { get; set; }

        [Display(Name = "Ngày kết thúc nhắc nhở")]
        public DateTime? ReminderEndDate { get; set; }

        [Display(Name = "Nhắc nhở")]
        public bool Reminder { get; set; }

        [Display(Name = "Tên đóng gói mặc định")]
        public string NamePackDefault { get; set; }

        [Display(Name = "Tên đóng gói")]
        public string[] NamePack { get; set; }

        [Display(Name = "Giá trị chuyển đổi")]
        public long[] ValuePack { get; set; }

        [Display(Name = "Id loại nguyên vật liệu")]
        public int IdMaterialType { get; set; }
    }
}