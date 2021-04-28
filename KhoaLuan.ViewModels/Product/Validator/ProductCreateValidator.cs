using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.Product
{
    public class ProductCreateValidator : AbstractValidator<ProductCreate>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Vui lòng nhập Mã số")
                .MaximumLength(20).WithMessage("Mã số không vượt quá 20 ký tự");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Vui lòng nhập Tên")
                .MaximumLength(150).WithMessage("Tên không vượt quá 150 ký tự");
        }
    }
}