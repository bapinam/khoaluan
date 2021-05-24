using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessingDetail
{
    public class ProcessingPlanVm
    {
        public long Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string CreatedDate { set; get; }
        public string CodeResponsible { set; get; }
    }
}