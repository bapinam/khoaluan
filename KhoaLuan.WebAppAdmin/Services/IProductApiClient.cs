using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IProductApiClient
    {
        Task<ApiResult<GetByIdListProduct>> Create(ProductCreate bundle);
        Task<ApiResult<GetIdPack>>  CreatePack (PackCreate bundle);
        Task<ApiResult<string>> UpdateImage(int id, IFormFile image);
        Task<ApiResult<UpdateReturn>> Update(int id, ProductUpdate bundle);

        Task<ApiResult<bool>> UpdateReminder(int id, UpdateReminder bundle);

        Task<ApiResult<bool>> UpdatePack(long id, UpdatePack bundle);

        Task<ApiResult<PagedResult<ProductVm>>> GetUsersPaging(GetProductPagingRequest bundle);

        Task<ApiResult<GetByIdProduct>> GetByIdProduct(int id);

        Task<ApiResult<GetReminder>> GetReminder(int id);

        Task<ApiResult<List<GetPack>>> GetPack(int id);

        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> DeletePack(long id);
        Task<ApiResult<bool>> iName(string name, int? id);
        Task<ApiResult<bool>> iNamePack(string name, int idSP, bool status, long? id);

    }
}