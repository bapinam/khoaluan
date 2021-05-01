using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.User
{
    public class UpdateImageUser
    {
        [Display(Name = "Tài khoản")]
        public string Name { get; set; }

        [Display(Name = "Hình ảnh")]
        public IFormFile File { get; set; }
    }
}