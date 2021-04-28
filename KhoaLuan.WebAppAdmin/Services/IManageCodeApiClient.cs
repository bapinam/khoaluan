using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.CodeManage;
using KhoaLuan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IManageCodeApiClient
    {
        Task<ApiResult<bool>> Create(CreateCode bundle);

        Task<List<GetAllCode>> GetAll(CodeType bundle);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> Update(UpdateCode bundle);

        Task<ApiResult<bool>> iName(string name, int? id);
    }
}