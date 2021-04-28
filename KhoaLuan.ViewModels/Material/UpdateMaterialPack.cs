using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Material
{
    public class UpdateMaterialPack
    {       
        public long Id { get; set; }

        [Display(Name = "Id nguyên vật liệu")]
        public int IdMaterial { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Giá trị chuyển đổi")]
        public long Value { get; set; }

        [Display(Name = "Mặc định")]
        public bool Default { get; set; }
    }
}
