using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public int IdProductTypeGroup { get; set; }
        public ProductTypeGroup ProductTypeGroup { get; set; }
    }
}