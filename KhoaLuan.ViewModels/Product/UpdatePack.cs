using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Product
{
    public class UpdatePack
    {       
        public long Id { get; set; }

        [Display(Name = "Id sản phẩm")]
        public int IdProduct { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Giá trị chuyển đổi")]
        public long Value { get; set; }

        [Display(Name = "Mặc định")]
        public bool Default { get; set; }
    }
}
