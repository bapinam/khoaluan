using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.UserService
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest bundle);

        Task<ApiResult<Guid>> Register(RegisterRequest bundle);

        Task<ApiResult<bool>> iCard(string card, Guid? id);

        Task<ApiResult<bool>> iEmail(string email, Guid? id);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest bundle);

        Task<ApiResult<bool>> UpdatePassword(Guid id, UserUpdatePassword bundle);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest bundle);

        Task<ApiResult<GetByIdListUser>> GetById(Guid id);

        Task<ApiResult<UserNameVm>> GetByUserName(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest bundle);
    }
}