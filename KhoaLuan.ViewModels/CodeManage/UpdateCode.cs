using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.CodeManage
{
    public class UpdateCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Top { get; set; }
        public CodeType TypeCode { get; set; }
    }
}