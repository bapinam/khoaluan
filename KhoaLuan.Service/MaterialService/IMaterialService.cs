using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Material;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.MaterialService
{
    public interface IMaterialService
    {
        Task<ApiResult<int>> Create(MaterialCreate bundle);
        Task<ApiResult<GetIdPackMaterial>> CreatePack(PackMaterialCreate bundle);
        Task<ApiResult<string>> UpdateImage(int id, ImageMaterial bundle);
        Task<ApiResult<int>> Update(int id, MaterialUpdate bundle);

        Task<ApiResult<bool>> UpdateReminder(UpdateMaterialReminder bundle);
        Task<ApiResult<bool>> UpdatePack(UpdateMaterialPack bundle);

        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> DeletePack(long id);

        Task<ApiResult<PagedResult<MaterialVm>>> GetUsersPaging(GetMaterialPagingRequest bundle);

        Task<ApiResult<GetByIdListMaterial>> GetById(int id);

        Task<ApiResult<UpdateMaterialReturn>> GetByUpdateMaterial(int id);

        Task<ApiResult<GetByIdMaterial>> GetByIdMaterial(int id);

        Task<ApiResult<GetMaterialReminder>> GetReminder(int id);

        Task<ApiResult<List<GetMaterialPack>>> GetPack(int id);

        Task<ApiResult<bool>> iName(string name, int? id);
        Task<ApiResult<bool>> iNamePack(string name, int idSP, bool status, long? id);
    }
}