using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.User;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Models;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;

        public UsersController(IUserApiClient userApiClient,
            IRoleApiClient roleApiClient,
            IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _userApiClient.GetUsersPagings(request);

            ViewBag.Keyword = keyword;

            //if (TempData["showuser"] != null)
            //{
            //    var st = TempData["showuser"] as string;
            //    string[] arrListStr = st.Split('~');
            //    ViewBag.SuccessMsg = "ShowUser";
            //    ViewBag.AddUser = new UserNameVm()
            //    {
            //        Code = arrListStr[0],
            //        UserName = arrListStr[1],
            //        Password = arrListStr[2]
            //    };
            //}

            return View(data.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<ApiResult<UserNameVm>> Create(RegisterRequest bundle)
        {
            var result = await _userApiClient.RegisterUser(bundle);
            //if (result.IsSuccessed)
            //{
            //    TempData["showuser"] = result.ResultObj.Code + "~" +
            //                         result.ResultObj.UserName + "~" +
            //                         result.ResultObj.Password;

            //    return RedirectToAction("Index");
            //}

            return result;
        }

        [HttpGet]
        public async Task<bool> iCard(string card, Guid? id)
        {
            var data = await _userApiClient.iCard(card, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<bool> iEmail(string email, Guid? id)
        {
            var data = await _userApiClient.iEmail(email, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<GetByIdListUser> GetById(Guid id)
        {
            var user = await _userApiClient.GetById(id);

            var data = new GetByIdListUser()
            {
                Code = user.ResultObj.Code,
                Card = user.ResultObj.Card,
                FirstName = user.ResultObj.FirstName,
                LastName = user.ResultObj.LastName,
                UserName = user.ResultObj.UserName,
                PhoneNumber = user.ResultObj.PhoneNumber,
                BirthDay = user.ResultObj.BirthDay,
                BirthDayF = user.ResultObj.BirthDayF,
                Gender = user.ResultObj.Gender,
                Address = user.ResultObj.Address,
                Email = user.ResultObj.Email,
                JobStatus = user.ResultObj.JobStatus
            };
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> Update(UserUpdateRequest bundle)
        {
            var data = await _userApiClient.UpdateUser(bundle.Id, bundle);
            return data;
        }

        [HttpDelete]
        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var data = await _userApiClient.Delete(id);
            return data;
        }
    }
}