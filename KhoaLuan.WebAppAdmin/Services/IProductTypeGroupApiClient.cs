using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProductTypeGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IProductTypeGroupApiClient
    {
        Task<ApiResult<GetByIdListProductTypeGroup>> Create(CreateProductTypeGroup bundle);

        Task<ApiResult<bool>> Update(int id, UpdateProductTypeGroup bundle);

        Task<ApiResult<PagedResult<ProductTypeGroupViewModel>>> GetUsersPaging(GetProductTypeGroupPagingRequest bundle);

        Task<ApiResult<GetByIdListProductTypeGroup>> GetById(int id);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> iName(string name, int? id);

        Task<List<GetAllProductTypeGroup>> GetAll();
    }
}