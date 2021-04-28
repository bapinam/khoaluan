using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface ISupplierApiClient
    {
        Task<ApiResult<GetByIdListSupplier>> Create(SupplierCreate bundle);

        Task<ApiResult<bool>> Update(int id, SupplierUpdate bundle);

        Task<ApiResult<PagedResult<SupplierVm>>> GetUsersPaging(GetSupplierPagingRequest bundle);

        Task<ApiResult<GetByIdListSupplier>> GetById(int id);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> iTax(string tax, int? id);

        Task<ApiResult<bool>> iEmail(string email, int? id);
    }
}