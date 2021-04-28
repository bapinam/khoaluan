using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Material
{
    public class GetIdPackMaterial
    {
        [Display(Name = "Id")]
        public long Id { set; get; }

        [Display(Name = "Tên đón gói")]
        public string Name { set; get; }

        [Display(Name = "Giá trị chuyển đổi")]
        public long Value { set; get; }
    }
}
