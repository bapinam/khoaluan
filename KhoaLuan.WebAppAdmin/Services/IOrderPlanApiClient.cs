using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
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

        Task<List<GetMaterialsPlan>> GetMaterialsSearch(int id, string key);

        Task<ApiResult<bool>> Create(CreateOrderPlan bundle);

        Task<List<GetEmployee>> GetEmployee(string key);

        Task<List<GetListSuppliersPlan>> GetListSuppliersPlan(string key);

        Task<List<GetByOrderPlan>> GetByOrderPlanCensorship();

        Task<ApiResult<bool>> UpdateOrderPlanCensorship(UpdateOrderPlanCensorship bundle);

        Task<ApiResult<bool>> Delete(long id);
    }
}