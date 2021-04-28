using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.MaterialsType;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.MaterialsTypeService
{
    public interface IMaterialsTypeService
    {
        Task<ApiResult<int>> Create(CreateMaterialsType bundle);

        Task<ApiResult<bool>> Update(int id, UpdateMaterialsType bundle);

        Task<ApiResult<PagedResult<MaterialsTypeViewModel>>> GetUsersPaging(GetMaterialsTypePagingRequest bundle);

        Task<ApiResult<GetByIdListMaterialsType>> GetById(int id);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> iName(string name, int? id);
        Task<List<GetAllMaterialsType>> GetAll();

    }
}