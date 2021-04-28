using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Recipe
{
    public class GetRecipePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int ProductType { get; set; }
    }
}
