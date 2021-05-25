using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessingDetail
{
    public class GetViewProcessingVocher
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string CodePlan { get; set; }
        public string CreateDate { get; set; }
        public string CompleteDate { get; set; }
        public bool Status { get; set; }
        public string CodeCreator { get; set; }
        public string CodeResponsible { get; set; }
        public List<ListRecipes> ListRecipes { get; set; }
    }

    public class ListRecipes
    {
        public long IdRecipes { get; set; }
        public string CodeRecipes { get; set; }
        public string CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}