using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.Service.Common;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly EnterpriseDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private const string PRODUCT_CONTENT_FOLDER_NAME = "product-content";

        public UserService(EnterpriseDbContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config, IMapper mapper,
            IStorageService storageService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest bundle)
        {
            if (bundle.UserName == null || bundle.Password == null)
            {
                return new ApiErrorResult<string>("Không được bỏ trống dữ liệu");
            }

            var user = await _userManager.FindByNameAsync(bundle.UserName);
            if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            // username, password, rememberme, true: login sai quá số lần sẽ bị khóa
            var result = await _signInManager.PasswordSignInAsync(user, bundle.Password, bundle.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Nhập mật khẩu sai");
            }

            if (user.JobStatus == JobStatus.Retired && user.AccountType != true)
            {
                return new ApiErrorResult<string>("Bạn không thể đăng nhập, vì bạn đã nghỉ việc");
            }

            var roles = await _userManager.GetRolesAsync(user);

            //var userRoles = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToArray();
            //var userClaims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);
            //var roleClaims = await GetRoleClaimAsync(roles).ConfigureAwait(false);

            var claims = new[]  // đẩy thông tin về token
            {
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, bundle.UserName),
                new Claim("Image", user.PathImage!= null ? user.PathImage : "OK"),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // sau khi có claims thì mã khóa claims  bằng Symmetric
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        private async Task<IList<Claim>> GetRoleClaimAsync(IList<string> data)
        {
            IList<Claim> roleClaims;

            foreach (var item in data)
            {
                var role = await _roleManager.FindByNameAsync(item);
                roleClaims = await _roleManager.GetClaimsAsync(role).ConfigureAwait(false);
            }
            throw new NotImplementedException();
        }

        public async Task<ApiResult<Guid>> Register(RegisterRequest bundle)
        {
            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);

            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var check = await _userManager.Users.AnyAsync(x => x.Code == str);
            if (check)
            {
                goto Location;
            }
            var userName = str;
            var passWord = "@Mk" + str;
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            user = _mapper.Map(bundle, user);
            user.Code = userName;
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

        public async Task<ApiResult<bool>> iEmailName(string email, string name)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == email && x.UserName != name))
            {
                return new ApiErrorResult<bool>("Email đã tồn tại tài khoản");
            }
            else
            {
                return new ApiSuccessResult<bool>();
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

        public async Task<ApiResult<bool>> UpdateInfor(UpdateInfor bundle)
        {
            var user = await _userManager.FindByIdAsync(bundle.Id.ToString());

            var list = _mapper.Map(bundle, user);

            var result = await _userManager.UpdateAsync(list);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<bool>> UpdatePassword(UserUpdatePassword bundle)
        {
            var user = await _userManager.FindByNameAsync(bundle.Name);
            if (user == null) return new ApiErrorResult<bool>("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, bundle.OldPassword, false, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<bool>("Nhập mật khẩu sai");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var update = await _userManager.ResetPasswordAsync(user, token, bundle.ConfirmPassword);
            if (update.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Mật khẩu phải có ít nhất ký tự đặc biệt và chữ hoa");
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
                    Address = x.Address,
                    JobStatus = x.JobStatus == JobStatus.NotWorking ? "Chưa có việc làm"
                                : x.JobStatus == JobStatus.Working ? "Đang làm việc" : "Đã nghỉ việc"
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
                    userVm.JobStatus = "Đã nghỉ việc";
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
            userVm.Password = "@Mk" + user.Code;
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
                userVm.JobStatus = "Chưa có việc làm";
            }

            if (user.JobStatus == JobStatus.Working)
            {
                userVm.JobStatus = "Đang làm việc";
            }

            if (user.JobStatus == JobStatus.Retired)
            {
                userVm.JobStatus = "Đã nghỉ việc";
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

            var role = await _userManager.GetRolesAsync(user);

            foreach (var item in role)
            {
                if (await _userManager.IsInRoleAsync(user, item))
                {
                    await _userManager.RemoveFromRoleAsync(user, item);
                }
            }
            if (user.PathImage != null)
            {
                await _storageService.DeleteFileAsync(user.PathImage);
            }

            var reult = await _userManager.DeleteAsync(user);
            if (reult.Succeeded)
                return new ApiSuccessResult<bool>();

            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<string>> UpdateJobStauts(UpdateJobStauts bundle)
        {
            var user = await _userManager.FindByIdAsync(bundle.Id.ToString());

            user.JobStatus = bundle.JobStatus;
            await _userManager.UpdateAsync(user);

            string js = "";
            if (user.JobStatus == JobStatus.NotWorking)
            {
                js = "Chưa có việc làm";
            }

            if (user.JobStatus == JobStatus.Working)
            {
                js = "Đang làm việc";
            }

            if (user.JobStatus == JobStatus.Retired)
            {
                js = "Đã nghỉ việc";
            }

            return new ApiSuccessResult<string>(js);
        }

        public async Task<ApiResult<GetByIdListUser>> GetByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
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
                    userVm.JobStatus = "Đã nghỉ việc";
                }
            }

            var date = user.BirthDay.ToString("dd-MM-yyyy");
            userVm.BirthDayF = date;
            var date2 = user.BirthDay.ToString("yyyy-MM-dd");
            userVm.BirthDay = date2;
            userVm.Id = user.Id;
            return new ApiSuccessResult<GetByIdListUser>(userVm);
        }

        public async Task<ApiResult<string>> UpdateImage(UpdateImageUser bundle)
        {
            var user = await _userManager.FindByNameAsync(bundle.Name);

            if (bundle.File != null)
            {
                if (user.PathImage != null)
                {
                    await _storageService.DeleteFileAsync(user.PathImage);
                }
            }

            // lưu lại ảnh mới
            user.PathImage = await this.SaveFile(bundle.File);
            await _userManager.UpdateAsync(user);
            return new ApiSuccessResult<string>(user.PathImage);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + PRODUCT_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<ApiResult<string>> GetImage(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user.PathImage != null)
            {
                return new ApiSuccessResult<string>(user.PathImage);
            }
            else
            {
                return new ApiErrorResult<string>();
            }
        }

        public async Task<ApiResult<bool>> ResetPassWord(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }

            var pass = "@Mk" + user.Code;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var update = await _userManager.ResetPasswordAsync(user, token, pass);

            if (update.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật thất bại");
        }
    }
}