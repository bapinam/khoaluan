using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.OrderPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IOrderPlanApiClient
    {
        Task<List<GetMaterialsTypePlan>> GetMaterialsType(GroupType group);
    }
}