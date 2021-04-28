using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Material;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IMaterialApiClient
    {
        Task<ApiResult<GetByIdListMaterial>> Create(MaterialCreate bundle);
        Task<ApiResult<GetIdPackMaterial>>  CreatePack (PackMaterialCreate bundle);
        Task<ApiResult<string>> UpdateImage(int id, IFormFile image);
        Task<ApiResult<UpdateMaterialReturn>> Update(int id, MaterialUpdate bundle);

        Task<ApiResult<bool>> UpdateReminder(int id, UpdateMaterialReminder bundle);

        Task<ApiResult<bool>> UpdatePack(long id, UpdateMaterialPack bundle);

        Task<ApiResult<PagedResult<MaterialVm>>> GetUsersPaging(GetMaterialPagingRequest bundle);

        Task<ApiResult<GetByIdMaterial>> GetByIdMaterial(int id);

        Task<ApiResult<GetMaterialReminder>> GetReminder(int id);

        Task<ApiResult<List<GetMaterialPack>>> GetPack(int id);

        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> DeletePack(long id);
        Task<ApiResult<bool>> iName(string name, int? id);
        Task<ApiResult<bool>> iNamePack(string name, int idLoai, bool status, long? id);

    }
}