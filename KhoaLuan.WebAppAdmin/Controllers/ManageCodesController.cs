using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.CodeManage;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    [Authorize(Policy = PolicyRecorads.Admin)]
    public class ManageCodesController : BaseController
    {
        private readonly IManageCodeApiClient _manageCodeApiClient;

        public ManageCodesController(IManageCodeApiClient manageCodeApiClient)
        {
            _manageCodeApiClient = manageCodeApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CodeType type)
        {
            var result = await _manageCodeApiClient.GetAll(type);
            return Ok(result);
        }

        [HttpGet]
        public async Task<bool> iName(string name, int? id)
        {
            var data = await _manageCodeApiClient.iName(name, id);
            return data.IsSuccessed;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCode bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _manageCodeApiClient.Create(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageCodeApiClient.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCode bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _manageCodeApiClient.Update(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}