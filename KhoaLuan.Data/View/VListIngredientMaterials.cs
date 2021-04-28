using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.View
{
    public class VListIngredientMaterial
    {
        public int IdMaterials { set; get; }
        public string NameMaterials { set; get; }
        public int Amount { set; get; }
        public string Unit { set; get; }

        public int IdReciper { set; get; }
        public VIngredientRecipe VIngredientRecipes { set; get; }
    }
}