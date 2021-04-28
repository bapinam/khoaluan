using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Product
{
    public class UpdateReturn
    {
        public int Id { get; set; }

        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Id loại sản phẩm")]
        public int IdProductType { get; set; }

        [Display(Name = "Tên loại sản phẩm")]
        public string NameProductType { get; set; }
    }
}
