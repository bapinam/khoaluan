using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class RecipeDetail
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }

        public int IdRecipe { get; set; }
        public Recipe Recipe { get; set; }

        public int IdMaterials { get; set; }
        public Material Material { get; set; }
    }
}