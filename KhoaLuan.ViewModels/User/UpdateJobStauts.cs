using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.User
{
    public class UpdateJobStauts
    {
        public Guid Id { set; get; }
        public JobStatus JobStatus { set; get; }
    }
}