﻿using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.OrderPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.OrderPlanService
{
    public interface IOrderPlanService
    {
        Task<List<GetMaterialsTypePlan>> GetMaterialsType(GroupType group);
    }
}