using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class GetProcessPlanByIdRecipes
    {
        public long Id { set; get; }
        public string Code { set; get; }
        public string DateMan { set; get; }
        public string ExpectedDate { set; get; }
        public bool Duration { set; get; }
        public string Name { set; get; }
        public string Note { set; get; }
        public string NameResponsible { set; get; }
        public Guid IdResponsible { set; get; }
        public string CodeResponsible { set; get; }
        public string Status { get; set; }
        public string CodeCreator { set; get; }
        public string CreatedDate { set; get; }
        public string CodeAuthority { set; get; }
        public List<ListProcessingDetailRecipes> ListProcessingDetails { get; set; }
    }

    public class ListProcessingDetailRecipes
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }

        public int IdRecipe { get; set; }
        public string CodeRecipe { get; set; }
    }
}