using System;
using System.Collections.Generic;

namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class GetByProcessPlanCensorship
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string ExpectedDate { get; set; }
        public string Note { get; set; }
        public string Status { set; get; }
        public bool Censorship { set; get; }
        public bool Duration { set; get; }
        public Guid IdCreator { get; set; }
        public string CodeCreator { get; set; }
        public string CodeResponsible { get; set; }
        public string NameResponsible { get; set; }
        public Guid IdResponsible { get; set; }
        public int Count { get; set; }
        public List<ListProcessingDetail> ListProcessingDetails { get; set; }
    }

    public class ListProcessingDetail
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }

        public int IdRecipe { get; set; }
        public string CodeRecipe { get; set; }
    }
}