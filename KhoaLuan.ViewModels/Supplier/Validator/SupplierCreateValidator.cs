using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.Supplier
{
    public class SupplierCreateValidator : AbstractValidator<SupplierCreate>
    {
        public SupplierCreateValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Vui lòng nhập Mã số")
                .MaximumLength(20).WithMessage("Mã số không vượt quá 20 ký tự");

            RuleFor(x => x.Tax).NotEmpty().WithMessage("Vui lòng nhập Mã số thuế");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Vui lòng nhập Tên")
                .MaximumLength(150).WithMessage("Tên không vượt quá 150 ký tự");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Vui lòng nhập email")
                .EmailAddress().WithMessage("Vui lòng nhập đúng địa chỉ email");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("vui lòng nhập số điện thoại")
                .Matches(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$")
                .WithMessage("Nhập định dạng điện thoại không đúng");
        }
    }
}