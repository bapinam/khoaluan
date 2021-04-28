using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProductTypeService
{
    public interface IProductTypeService
    {
        Task<ApiResult<int>> Create(CreateProductType bundle);

        Task<ApiResult<bool>> Update(int id, UpdateProductType bundle);

        Task<ApiResult<PagedResult<ProductTypeViewModel>>> GetUsersPaging(GetProductTypePagingRequest bundle);

        Task<ApiResult<GetByIdListProductType>> GetById(int id);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> iName(string name, int? id);

        Task<List<GetAllProductType>> GetAll();
    }
}