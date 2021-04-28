using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Product
{
    public class GetReminder
    {
        [Display(Name = "Mức tồn tối thiểu")]
        public long? Min { get; set; }

        [Display(Name = "Mức tồn tối đa")]
        public long? Max { get; set; }

        [Display(Name = "Ngày bắt đầu nhắc nhở")]
        public string ReminderStartDate { get; set; }

        [Display(Name = "Ngày kết thúc nhắc nhở")]
        public string ReminderEndDate { get; set; }

        [Display(Name = "Nhắc nhở")]
        public bool Reminder { get; set; }
    }
}