using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class MaterialsType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public GroupType GroupType { get; set; }
        public List<Material> Materials { get; set; }
    }
}