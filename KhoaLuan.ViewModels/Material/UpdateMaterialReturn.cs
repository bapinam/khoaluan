using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Material
{
    public class UpdateMaterialReturn
    {
        public int Id { get; set; }

        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Tên nguyên vật liệu")]
        public string Name { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Id loại nguyên vật liệu")]
        public int IdMaterialType { get; set; }

        [Display(Name = "Tên loại nguyên vật liệu")]
        public string NameMaterialType { get; set; }
    }
}
