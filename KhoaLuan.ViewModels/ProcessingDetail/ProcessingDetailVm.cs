using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProcessingDetail
{
    public class ProcessingDetailVm
    {
        public string CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public long IdProcess { get; set; }
        public string UnitProcess { get; set; }
        public int AmountProcess { get; set; }
        public int EnterAmountProcess { get; set; }
        public long IdRecipes { get; set; }
        public string CodeRecipes { get; set; }
        public List<RecipeMaterials> RecipeMaterials { get; set; }
    }
}