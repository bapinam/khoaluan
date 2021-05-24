using System.Collections.Generic;

namespace KhoaLuan.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Prioritize { get; set; }
        public string Note { get; set; }

        public int IdProduct { get; set; }
        public Product Product { get; set; }

        public List<ProcessingDetail> ProcessingDetails { get; set; }
        public List<RecipeDetail> RecipeDetails { get; set; }
        public List<ProcessingVoucherDetail> ProcessingVoucherDetails { get; set; }
    }
}