using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Decentralization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IRoleApiClient
    {
        Task<List<string>> GetRole(Guid id);

        Task<ApiResult<bool>> Assign(AssignVm bundle);
    }
}