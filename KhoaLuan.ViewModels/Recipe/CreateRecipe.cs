using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Recipe
{
    public class CreateRecipe
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Prioritize { get; set; }
        public string Note { get; set; }

        public int IdProduct { get; set; }

        public int[] IdMaterials { get; set; }

        public int[] Amount { get; set; }

        public string[] Unit { get; set; }
    }
}