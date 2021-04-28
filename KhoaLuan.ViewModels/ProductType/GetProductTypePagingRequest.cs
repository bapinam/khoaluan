using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProductType
{
    public class GetProductTypePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int GroupType { get; set; }
    }
}