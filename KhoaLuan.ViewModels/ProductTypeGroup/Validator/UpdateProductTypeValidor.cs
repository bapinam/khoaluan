using FluentValidation;
using KhoaLuan.ViewModels.ProductTypeGroup;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.ProductTypeGroup
{
    public class UpdateProductTypeGroupValidor : AbstractValidator<UpdateProductTypeGroup>
    {
        public UpdateProductTypeGroupValidor()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Vui lòng nhập id");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Vui lòng nhập mã số");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Vui lòng nhập tên loại")
                .MaximumLength(150).WithMessage("Tên loại có độ dài dưới 150 ký tự");
        }
    }
}