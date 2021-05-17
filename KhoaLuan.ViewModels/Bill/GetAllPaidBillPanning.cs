using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Bill
{
    public class GetAllPaidBillPanning : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}