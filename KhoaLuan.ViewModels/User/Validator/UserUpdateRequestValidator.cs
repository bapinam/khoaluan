using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.User
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Vui lòng nhập Tên")
                .MaximumLength(50).WithMessage("Tên không vượt quá 50 ký tự");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Vui lòng nhập Họ")
                    .MaximumLength(50).WithMessage("Họ không vượt quá 50 ký tự");

            RuleFor(x => x.BirthDay).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Ngày sinh không được lớn hơn 100 năm");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Vui lòng nhập đúng địa chỉ email");
        }
    }
}