using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.MaterialsType
{
    public class GetMaterialsTypePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int GroupType { get; set; }
    } 
}