namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class ProcessPlanVm
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { set; get; }
        public string CreatedDate { get; set; }
        public string CodeCreator { get; set; }
        public string CodeResponsible { get; set; }
    }
}