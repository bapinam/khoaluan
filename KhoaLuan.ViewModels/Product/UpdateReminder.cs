using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Product
{
    public class UpdateReminder
    {
        public int Id { get; set; }

        [Display(Name = "Mức tồn tối thiểu")]
        public long Min { get; set; }

        [Display(Name = "Mức tồn tối đa")]
        public long Max { get; set; }

        [Display(Name = "Ngày nhắc nhở")]
        public string DateReminder { get; set; }

        [Display(Name = "Nhắc nhở")]
        public bool BoolReminder { get; set; }
    }
}