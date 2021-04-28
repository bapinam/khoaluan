﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.ProductType
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Tên loại")]
        public string Name { get; set; }

        [Display(Name = "Nhóm loại")]
        public string GroupType { get; set; }
    }
}