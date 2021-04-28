using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KhoaLuan.ViewModels.Material
{
    public class GetMaterialPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int MaterialType { get; set; }
    }
}