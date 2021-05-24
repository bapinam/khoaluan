using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessingDetail
{
    public class RecipeMaterials
    {
        public int IdMaterials { get; set; }
        public string NameMaterials { get; set; }
        public string CodeMaterials { get; set; }
        public string UnitRecipe { get; set; }
        public int AmountRecipe { get; set; }
        public long AmountMaterials { get; set; }
        public long ValuePack { get; set; }
    }
}