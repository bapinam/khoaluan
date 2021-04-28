using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Recipe
{
    public class GetListIdRecipe
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Note { set; get; }
        public bool Prioritize { set; get; }

        public List<IngredientRecipe> IngredientRecipes { set; get; }
    }
}