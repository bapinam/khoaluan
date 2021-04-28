using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.User
{
    public class UserUpdatePasswordValidator : AbstractValidator<UserUpdatePassword>
    {
        public UserUpdatePasswordValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Vui lòng nhập mật khẩu củ")
                .MinimumLength(6).WithMessage("Mật khẩu có độ dài ít nhất 6 ký tự");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Vui lòng nhập mật khẩu mới")
                .MinimumLength(6).WithMessage("Mật khẩu có độ dài ít nhất 6 ký tự");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Nhập mật khẩu mới không khớp");
                }
            });
        }
    }
}