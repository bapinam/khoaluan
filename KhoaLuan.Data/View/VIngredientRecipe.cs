namespace KhoaLuan.Data.View
{
    public class VIngredientRecipe
    {
        public int IdReciper { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public bool Prioritize { set; get; }
        public string Note { set; get; }

        public int IdMaterials { set; get; }
        public string NameMaterials { set; get; }
        public int Amount { set; get; }
        public string Unit { set; get; }
        //  public List<VListIngredientMaterial> VListIngredientMaterials { set; get; }
    }
}