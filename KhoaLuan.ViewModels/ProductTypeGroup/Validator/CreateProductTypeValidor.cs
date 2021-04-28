using FluentValidation;
using KhoaLuan.ViewModels.ProductTypeGroup;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.ProductTypeGroup
{
    public class CreateProductTypeGroupValidor : AbstractValidator<CreateProductTypeGroup>
    {
        public CreateProductTypeGroupValidor()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Vui lòng nhập mã số");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Vui lòng nhập tên loại")
                .MaximumLength(150).WithMessage("Tên loại có độ dài dưới 150 ký tự");
        }
    }
}