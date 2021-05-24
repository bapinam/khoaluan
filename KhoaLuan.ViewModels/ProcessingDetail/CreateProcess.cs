using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessingDetail
{
    public class CreateProcess
    {
        public long[] IdProcess { get; set; }
        public int[] Amount { get; set; }
        public long IdPlan { get; set; }
        public string NameCreator { get; set; }
        public string Code { get; set; }
    }
}