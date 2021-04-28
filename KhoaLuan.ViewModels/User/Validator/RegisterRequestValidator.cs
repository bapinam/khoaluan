using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.User
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Vui lòng nhập Mã số")
                .MaximumLength(20).WithMessage("Mã số không vượt quá 20 ký tự");

            RuleFor(x => x.Card).NotEmpty().WithMessage("Vui lòng nhập Chứng minh thư")
                .Matches(@"^\(?([0-9]{12})$")
                .WithMessage("Nhập đủ 12 số");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Vui lòng nhập Tên")
                .MaximumLength(50).WithMessage("Tên không vượt quá 50 ký tự");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Vui lòng nhập Họ")
                .MaximumLength(50).WithMessage("Họ không vượt quá 50 ký tự");

            RuleFor(x => x.BirthDay)
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Ngày sinh không được lớn hơn 100 năm");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Vui lòng nhập email")
                .EmailAddress().WithMessage("Vui lòng nhập đúng địa chỉ email");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("vui lòng nhập số điện thoại")
                .Matches(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$")
                .WithMessage("Nhập định dạng điện thoại không đúng");
        }
    }
}