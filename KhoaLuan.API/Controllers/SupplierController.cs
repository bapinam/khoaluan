using KhoaLuan.Service.SupplierService;
using KhoaLuan.ViewModels.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ListRole.Records)]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _supplierService.Create(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }

            var result = await _supplierService.GetById(resultId.ResultObj);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetSupplierPagingRequest request)
        {
            var result = await _supplierService.GetUsersPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _supplierService.GetById(id);
            return Ok(user);
        }

        [Authorize(Roles = ListRole.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _supplierService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("check-tax")]
        public async Task<IActionResult> iTax(string tax, int? id)
        {
            var resultId = await _supplierService.iTax(tax, id);
            return Ok(resultId);
        }

        [HttpGet("check-email")]
        public async Task<IActionResult> iEmail(string email, int? id)
        {
            var resultId = await _supplierService.iEmail(email, id);
            return Ok(resultId);
        }
    }
}