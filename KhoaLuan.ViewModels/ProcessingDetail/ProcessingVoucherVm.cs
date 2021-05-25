using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessingDetail
{
    public class ProcessingVoucherVm
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long IdPlan { get; set; }
        public string CodePlan { get; set; }
        public string CreateDate { get; set; }
        public string NameResponsible { get; set; }
        public string Creator { get; set; }
    }

    public class ListProcessingVoucher
    {
        public int Count { get; set; }
        public List<ProcessingVoucherVm> ProcessingVoucherVms { get; set; }
    }
}