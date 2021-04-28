using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Recipe
{ 

    public class IngredientRecipe
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public int Amount { set; get; }
        public string Unit { set; get; }
    }
}

