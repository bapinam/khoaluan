using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Entities
{
    public class ManageCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Top { get; set; }
        public CodeType TypeCode { get; set; }
        public long Location { set; get; }
    }
}