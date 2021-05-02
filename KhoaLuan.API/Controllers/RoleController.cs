using KhoaLuan.Service.RoleService;
using KhoaLuan.ViewModels.Decentralization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = PolicyRecorads.Admin)]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(Guid id)

        {
            var roles = await _roleService.GetRole(id);
            return Ok(roles);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign(AssignVm bundle)
        {
            var roles = await _roleService.Assign(bundle);
            return Ok(roles);
        }
    }
}