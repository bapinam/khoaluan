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
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsRoleClaims.View));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsRoleClaims.Add));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsRoleClaims.Edit));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, RecordsRoleClaims.Reminder));
            }

            // Employee
            var nameEmployee = await _roleManager.FindByNameAsync(RoleDecentralization.Employee.ToString());
            if (nameEmployee == null)
            {
                nameEmployee = new AppRole(RoleDecentralization.Employee.ToString());
                nameEmployee.Description = "Vai trò nhân viên";

                await _roleManager.CreateAsync(nameEmployee);

                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, EmployeeRoleClaims.View));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, EmployeeRoleClaims.Add));
                await _roleManager
                    .AddClaimAsync(name, new Claim(CustomClaimTypes.Permission, EmployeeRoleClaims.Edit));
            }

            // ADMIN
            var roleAdmin = await _roleManager.FindByNameAsync(RoleDecentralization.Admin.ToString());

            var claimAdmin = await _roleManager.GetClaimsAsync(roleAdmin).ConfigureAwait(false);

            var count = claimAdmin.Count();
            if (count < 1)
            {
                await _roleManager
                    .AddClaimAsync(roleAdmin, new Claim(CustomClaimTypes.Permission, AdminRoleClaims.Admin));
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