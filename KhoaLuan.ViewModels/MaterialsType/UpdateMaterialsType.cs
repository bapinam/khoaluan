﻿using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KhoaLuan.ViewModels.MaterialsTypeViewModel
{
    public class UpdateMaterialsType
    {
        public int Id { get; set; }

        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Tên loại")]
        public string Name { get; set; }

        [Display(Name = "Nhóm loại")]
        public GroupType GroupType { get; set; }
    }
}