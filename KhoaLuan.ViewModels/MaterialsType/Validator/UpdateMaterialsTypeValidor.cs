using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.ViewModels.MaterialsTypeViewModel
{
    public class UpdateMaterialsTypeValidor : AbstractValidator<UpdateMaterialsType>
    {
        public UpdateMaterialsTypeValidor()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Vui lòng nhập id");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Vui lòng nhập mã số");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Vui lòng nhập tên loại")
                .MaximumLength(150).WithMessage("Tên loại có độ dài dưới 150 ký tự");
            RuleFor(x => x.GroupType).NotNull().WithMessage("Vui lòng chọn nhóm loại");
        }
    }
}