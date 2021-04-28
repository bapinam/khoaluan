﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long Amount { get; set; }
        public long? Min { get; set; }
        public long? Max { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public DateTime ReminderStartDate { get; set; }
        public DateTime ReminderEndDate { get; set; }
        public bool Reminder { get; set; }

        public int IdMaterialsType { get; set; }
        public MaterialsType MaterialsType { get; set; }

        public List<BillDetail> BillDetails { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Pack> Packs { get; set; }
        public List<RecipeDetail> RecipeDetails { get; set; }
    }
}