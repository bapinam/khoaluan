using KhoaLuan.Data.Enums;
using KhoaLuan.Service.ManageCodeService;
using KhoaLuan.ViewModels.CodeManage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManageCodeController : ControllerBase
    {
        private readonly IManageCodeService _manageCodeService;

        public ManageCodeController(IManageCodeService manageCodeService)
        {
            _manageCodeService = manageCodeService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CodeType type)
        {
            var result = await _manageCodeService.GetAll(type);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCode bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _manageCodeService.Create(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageCodeService.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCode bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _manageCodeService.Update(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("check-name")]
        public async Task<IActionResult> iName(string name, int? id)
        {
            var result = await _manageCodeService.iName(name, id);
            return Ok(result);
        }
    }
}