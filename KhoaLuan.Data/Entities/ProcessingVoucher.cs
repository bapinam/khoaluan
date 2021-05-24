using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Entities
{
    public class ProcessingVoucher
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long IdPlan { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public ProcessPlan ProcessPlan { get; set; }
        public AppUser Creator { get; set; }
        public Guid IdCreator { get; set; }

        public List<ProcessingVoucherDetail> ProcessingVoucherDetails { get; set; }
    }
}