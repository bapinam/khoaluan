using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KhoaLuan.ViewModels.Supplier
{
    public class GetSupplierPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}