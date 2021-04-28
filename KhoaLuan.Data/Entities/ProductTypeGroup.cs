using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Entities
{
    public class ProductTypeGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<ProductType> ProductTypes { get; set; }
    }
}