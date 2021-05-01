using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Decentralization;
using KhoaLuan.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.Service.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ApiResult<bool>> Assign(AssignVm bundle)
        {
            var user = await _userManager.FindByIdAsync(bundle.IdUser.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }

            // RecordsManagement
            await UpdateRole(user, bundle.RecordsManagement);

            return new ApiSuccessResult<bool>();
        }

        private async Task UpdateRole(AppUser user, string name)
        {
            var role = await _roleManager.FindByNameAsync(RoleDecentralization.RecordsManagement.ToString());
            if (name != null && name == ListRole.RecordsManagement)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }
            else
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
        }

        public async Task CreateRole()
        {
            // RecordsManagement
            var name = await _roleManager.FindByNameAsync(RoleDecentralization.RecordsManagement.ToString());
            if (name == null)
            {
                name = new AppRole(RoleDecentralization.RecordsManagement.ToString());
                name.Description = "Vai trò quản lý hồ sơ";

                await _roleManager.CreateAsync(name);

                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsManagementsRole.View));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsManagementsRole.Add));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsManagementsRole.Edit));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsManagementsRole.Reminder));
            }
        }

        public async Task<List<string>> GetRole(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var role = await _userManager.GetRolesAsync(user);

            return new List<string>(role);
        }
    }
}