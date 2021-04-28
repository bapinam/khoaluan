using AutoMapper;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _mapper = mapper;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest bundle)
        {
            var user = await _userManager.FindByNameAsync(bundle.UserName);
            if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            // username, password, rememberme, true: login sai quá số lần sẽ bị khóa
            var result = await _signInManager.PasswordSignInAsync(user, bundle.Password, bundle.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Nhập mật khẩu sai");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]  // đẩy thông tin về token
            {
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, bundle.UserName)
            };

            // sau khi có claims thì mã khóa claims  bằng Symmetric
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<Guid>> Register(RegisterRequest bundle)
        {
            Random _r = new Random();
            int n = _r.Next();
            var userName = "nam" + n;
            var passWord = "$Nhanvien123";
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return new ApiErrorResult<Guid>("Tài khoản đã tồn tại");
            }

            user = _mapper.Map(bundle, user);
            user.UserName = userName;
            user.JobStatus = JobStatus.NotWorking;
            var result = await _userManager.CreateAsync(user, passWord);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<Guid>(user.Id);
            }
            return new ApiErrorResult<Guid>("Đăng ký không thành công");
        }

        public async Task<ApiResult<bool>> iCard(string card, Guid? id)
        {
            if (id != null)
            {
                if (await _userManager.Users.AnyAsync(x => x.Card == card && x.Id != id))
                {
                    return new ApiErrorResult<bool>("Chứng minh đã tồn tại tài khoản");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                if (await _userManager.Users.AnyAsync(x => x.Card == card))
                {
                    return new ApiErrorResult<bool>("Chứng minh đã tồn tại tài khoản");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }

        public async Task<ApiResult<bool>> iEmail(string email, Guid? id)
        {
            if (id != null)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == email && x.Id != id))
                {
                    return new ApiErrorResult<bool>("Email đã tồn tại tài khoản");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == email))
                {
                    return new ApiErrorResult<bool>("Email đã tồn tại tài khoản");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest bundle)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var list = _mapper.Map(bundle, user);

            var result = await _userManager.UpdateAsync(list);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<bool>> UpdatePassword(Guid id, UserUpdatePassword bundle)
        {
            if (!await _userManager.Users.AnyAsync(x => x.PasswordHash == bundle.OldPassword && x.Id == id))
            {
                return new ApiErrorResult<bool>("Mật khẩu không đúng");
            }

            var user = await _userManager.FindByIdAsync(id.ToString());

            user.PasswordHash = bundle.Password;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật mật khẩu không thành công");
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest bundle)
        {
            var query = _userManager.Users.Where(x => x.AccountType != true);
            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(x => x.Code.Contains(bundle.Keyword) || x.Card.Contains(bundle.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(x => new UserVm()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Card = x.Card,
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    Gender = x.Gender == true ? "Nam" : "Nữ",
                    BirthDay = x.BirthDay,
                    Address = x.Address
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<ApiResult<GetByIdListUser>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<GetByIdListUser>("Người dùng không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = _mapper.Map<GetByIdListUser>(user);
            if (user.Gender)
            {
                userVm.Gender = "Nam";
            }
            else
            {
                userVm.Gender = "Nữ";
            }

            if (user.JobStatus == JobStatus.NotWorking)
            {
                userVm.JobStatus = "Chưa làm việc";
            }
            else
            {
                if (user.JobStatus == JobStatus.Working)
                {
                    userVm.JobStatus = " Đang làm việc";
                }
                else
                {
                    userVm.JobStatus = "Nghỉ làm việc";
                }
            }

            var date = user.BirthDay.ToString("dd-MM-yyyy");
            userVm.BirthDayF = date;
            var date2 = user.BirthDay.ToString("yyyy-MM-dd");
            userVm.BirthDay = date2;
            return new ApiSuccessResult<GetByIdListUser>(userVm);
        }

        public async Task<ApiResult<UserNameVm>> GetByUserName(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserNameVm>("Người dùng không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = _mapper.Map<UserNameVm>(user);
            userVm.Password = "$Nhanvien123";
            if (user.Gender)
            {
                userVm.Gender = "Nam";
            }
            else
            {
                userVm.Gender = "Nữ";
            }

            return new ApiSuccessResult<UserNameVm>(userVm);
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Người dùng không tồn tại");
            }

            var reult = await _userManager.DeleteAsync(user);
            if (reult.Succeeded)
                return new ApiSuccessResult<bool>();

            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest bundle)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }
            var removedRoles = bundle.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var addedRoles = bundle.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return new ApiSuccessResult<bool>();
        }
    }
}