using KhoaLuan.ViewModels.Bill;
using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.BillService
{
    public interface IBillService
    {
        Task<List<GetByOrderPlanBills>> GetByOrderPlanBills(string key);

        Task<List<GetByIdOrderPlanBills>> GetByIdOrderPlanBills(long id);

        Task<List<GetAllSuppliersBill>> GetAllSuppliers(string key);

        Task<List<GetAllPaymentStautsBill>> GetAllUnpaidBill(string key);

        Task<ApiResult<PagedResult<GetAllPaymentStautsBill>>> GetAllPaidBill(GetAllPaidBillPanning bundle);

        Task<ApiResult<GetBillById>> GetBillById(long id);

        Task<ApiResult<long>> Create(CreateBill bundle);

        Task<ApiResult<ReturnUpdate>> Update(UpdateBill bundle);

        Task<ApiResult<bool>> Delete(long id);

        Task<ApiResult<bool>> UpdateUnpaid(UpdateUnpaid bundle);
    }
}