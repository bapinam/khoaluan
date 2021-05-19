using System.Collections.Generic;

namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class GetAllProductRecipes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long Amount { get; set; }
        public long? Max { get; set; }

        public List<AllRecipes> AllRecipes { get; set; }
    }

    public class AllRecipes
    {
        public int IdRecipes { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}