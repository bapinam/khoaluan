using FluentValidation;
using KhoaLuan.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.User
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Vui lòng nhập tài khoản");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Vui lòng nhập mật khẩu")
                .MinimumLength(6).WithMessage("Mật khẩu lớn hơn 6 ký tự");
        }
    }
}