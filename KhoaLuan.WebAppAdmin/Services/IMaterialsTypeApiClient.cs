using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.MaterialsType;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IMaterialsTypeApiClient
    {
        Task<ApiResult<GetByIdListMaterialsType>> Create(CreateMaterialsType bundle);

        Task<ApiResult<bool>> Update(int id, UpdateMaterialsType bundle);

        Task<ApiResult<PagedResult<MaterialsTypeViewModel>>> GetUsersPaging(GetMaterialsTypePagingRequest bundle);

        Task<ApiResult<GetByIdListMaterialsType>> GetById(int id);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> iName(string name, int? id);
        Task<List<GetAllMaterialsType>> GetAll();

    }
}