using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Decentralization;
using KhoaLuan.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.RoleService
{
    public interface IRoleService
    {
        Task CreateRole();

        Task<List<string>> GetRole(Guid id);

        Task<ApiResult<bool>> Assign(AssignVm bundle);
    }
}