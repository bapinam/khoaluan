using System;

namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class CreatePlan
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime ExpectedDate { get; set; }

        public int[] IdMaterials { get; set; }
        public int[] Amount { get; set; }
        public string[] Pack { get; set; }

        public Guid IdResponsible { get; set; }
        public string NameCreator { get; set; }
    }
}