using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Recipe
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Mã số")]
        public string Code { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Ưu tiên")]
        public int Prioritize { get; set; }
        [Display(Name = "Ghi Chú")]
        public string Note { get; set; }
        [Display(Name = "Id sản phẩm")]
        public int IdProduct { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string NameProduct { get; set; }
    }
}
