using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class Pack
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }
        public bool Default { get; set; }
        public PackType PackType { get; set; }

        public int? IdProduct { get; set; }
        public int? IdMaterials { get; set; }
        public Material Material { get; set; }
        public Product Product { get; set; }
    }
}