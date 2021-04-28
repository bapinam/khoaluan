using FluentValidation;
using KhoaLuan.ViewModels.ProductType;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.ProductType
{
    public class CreateProductTypeValidor : AbstractValidator<CreateProductType>
    {
        public CreateProductTypeValidor()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Vui lòng nhập mã số");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Vui lòng nhập tên loại")
                .MaximumLength(150).WithMessage("Tên loại có độ dài dưới 150 ký tự");
            RuleFor(x => x.IdProductTypeGroup).NotEmpty().WithMessage("Vui lòng chọn nhóm loại");
        }
    }
}