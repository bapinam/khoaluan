using KhoaLuan.ViewModels.Bill;
using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IBillApiClient
    {
        Task<List<GetByOrderPlanBills>> GetByOrderPlanBills(string key);

        Task<List<GetByIdOrderPlanBills>> GetByIdOrderPlanBills(long id);

        Task<List<GetAllSuppliersBill>> GetAllSuppliers(string key);

        Task<List<GetAllPaymentStautsBill>> GetAllUnpaidBill(string key);

        Task<ApiResult<PagedResult<GetAllPaymentStautsBill>>> GetAllPaidBill(GetAllPaidBillPanning bundle);

        Task<ApiResult<GetBillById>> GetBillById(long id);

        Task<ApiResult<GetBillById>> Create(CreateBill bundle);

        Task<ApiResult<ReturnUpdate>> Update(UpdateBill bundle);

        Task<ApiResult<bool>> Delete(long id);

        Task<ApiResult<bool>> UpdateUnpaid(UpdateUnpaid bundle);

        Task<ApiResult<bool>> CancelBills(long id);

        Task<ApiResult<bool>> SplitBills(long id);

        Task<ApiResult<bool>> CombinedBills(CombinedBills bundle);
    }
}