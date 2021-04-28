using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Supplier;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.SupplierService
{
    public interface ISupplierService
    {
        Task<ApiResult<int>> Create(SupplierCreate bundle);

        Task<ApiResult<bool>> Update(int id, SupplierUpdate bundle);

        Task<ApiResult<PagedResult<SupplierVm>>> GetUsersPaging(GetSupplierPagingRequest bundle);

        Task<ApiResult<GetByIdListSupplier>> GetById(int id);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> iTax(string tax, int? id);

        Task<ApiResult<bool>> iEmail(string email, int? id);
    }
}