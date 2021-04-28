using KhoaLuan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Material
{
    public class GetMaterialPack
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }
        public bool Default { get; set; }
        public long Change { get; set; }
    }
}
