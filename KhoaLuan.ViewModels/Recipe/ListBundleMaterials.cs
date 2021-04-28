using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Recipe
{
    public class ListBundleMaterials
    {
        public GroupType? GroupTypeMaterials { set; get; }
        public int MaterialsType { set; get; }
        public string KeyWordNL { set; get; }
    }
}