using System;

namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class UpdatePlan
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime ExpectedDate { get; set; }

        public Guid IdResponsible { get; set; }
    }
}