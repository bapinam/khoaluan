using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}