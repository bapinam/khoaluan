using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KhoaLuan.ViewModels.User
{
    public class GetByIdListUser
    {
        public Guid Id { get; set; }

        [Display(Name = "Mã số")]
        public string Code { get; set; }

        [Display(Name = "Chứng minh thư")]
        public string Card { get; set; }

        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Ngày sinh chuỗi")]
        public string BirthDayF { get; set; }

        [Display(Name = "Ngày sinh ")]
        public string BirthDay { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        public IList<string> Roles { get; set; }

        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Tình Trạng Làm")]
        public string JobStatus { get; set; }

        [Display(Name = "Hình ảnh")]
        public string PathImage { get; set; }
    }
}