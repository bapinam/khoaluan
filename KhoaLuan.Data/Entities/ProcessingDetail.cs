using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class ProcessingDetail
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public int EnterAmount { get; set; }
        public string Unit { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }

        public int IdRecipe { get; set; }
        public long IdProcessPlan { get; set; }
        public Recipe Recipe { get; set; }
        public ProcessPlan ProcessPlan { get; set; }
    }
}