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
        Task<ApiResult<PagedResult<OrderPlanVm>>> GetOrderPlanPaging(GetOrderPlanPagingRequest bundle);

        Task<List<GetMaterialsTypePlan>> GetMaterialsType(GroupType group);

        Task<List<GetMaterialsPlan>> GetMaterialsSearch(int id, string key);

        Task<ApiResult<bool>> Create(CreateOrderPlan bundle);

        Task<List<GetListPacksById>> GetListPacksById(int id);

        Task<List<GetEmployee>> GetEmployee(string key);

        Task<List<GetListSuppliersPlan>> GetListSuppliersPlan(string key);

        Task<List<GetByOrderPlan>> GetByOrderPlanCensorship();

        Task<List<GetByOrderPlan>> GetByOrderPlanApproved(string key);

        Task<ApiResult<bool>> UpdateOrderPlanCensorship(UpdateOrderPlanCensorship bundle);

        Task<ApiResult<bool>> Delete(long id);

        Task<ApiResult<GetOrderPlan>> GetOrderPlan(long id);

        Task<ApiResult<GetByOrderPlan>> GetByIdOrderPlan(long id);

        Task<ApiResult<GetOrderPlan>> Update(UpdateOrderPlan bundle);
    }
}