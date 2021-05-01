using KhoaLuan.ViewModels.Decentralization;
using KhoaLuan.ViewModels.User;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    [Authorize(Roles = ListRole.Admin)]
    public class DecentralizationsController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;

        public DecentralizationsController(IUserApiClient userApiClient,
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

            await _roleApiClient.CreateRole();

            return View(data.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(AssignVm bundle)
        {
            var result = await _roleApiClient.Assign(bundle);
            return Ok(result.IsSuccessed);
        }

        [HttpGet]
        public async Task<IActionResult> GetRole(Guid id)

        {
            var roles = await _roleApiClient.GetRole(id);
            return Ok(roles);
        }
    }
}