using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProductService
{
    public interface IProductService
    {
        Task<ApiResult<int>> Create(ProductCreate bundle);
        Task<ApiResult<GetIdPack>> CreatePack(PackCreate bundle);
        Task<ApiResult<string>> UpdateImage(int id, ImageProduct bundle);
        Task<ApiResult<int>> Update(int id, ProductUpdate bundle);

        Task<ApiResult<bool>> UpdateReminder(UpdateReminder bundle);
        Task<ApiResult<bool>> UpdatePack(UpdatePack bundle);

        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> DeletePack(long id);

        Task<ApiResult<PagedResult<ProductVm>>> GetUsersPaging(GetProductPagingRequest bundle);

        Task<ApiResult<GetByIdListProduct>> GetById(int id);

        Task<ApiResult<UpdateReturn>> GetByUpdateProduct(int id);

        Task<ApiResult<GetByIdProduct>> GetByIdProduct(int id);

        Task<ApiResult<GetReminder>> GetReminder(int id);

        Task<ApiResult<List<GetPack>>> GetPack(int id);

        Task<ApiResult<bool>> iName(string name, int? id);
        Task<ApiResult<bool>> iNamePack(string name, int idSP, bool status, long? id);
    }
}