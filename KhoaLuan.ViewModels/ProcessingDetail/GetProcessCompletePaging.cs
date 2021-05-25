using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessingDetail
{
    public class GetProcessCompletePaging : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}