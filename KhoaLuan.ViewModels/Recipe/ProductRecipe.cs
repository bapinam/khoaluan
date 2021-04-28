using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Recipe
{
    public class ProductRecipe
    {
        [Display(Name = "Id")]
        public int Id { set; get; }
        [Display(Name = "Mã Số")]
        public string Code { set; get; }
        [Display(Name = "Tên")]
        public string Name { set; get; }
        [Display(Name = "Hình ảnh")]
        public string Image { set; get; }
        [Display(Name = "Tên công thức")]
        public string NameRecipe { set; get; }
        [Display(Name = "Tên loại sản phẩm")]
        public string NameProductType { set; get; }
    }
}
