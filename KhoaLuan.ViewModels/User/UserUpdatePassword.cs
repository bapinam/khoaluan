using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KhoaLuan.ViewModels.User
{
    public class UserUpdatePassword
    {
        [Display(Name = "Tên tài khoản")]
        [DataType(DataType.Password)]
        public string Name { get; set; }

        [Display(Name = "Mật khẩu mới củ")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu mới")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}