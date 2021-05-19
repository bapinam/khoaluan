using System;

namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class GetProcessPlanById
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
    }
}