using KhoaLuan.Service.ProductTypeGroupService;
using KhoaLuan.ViewModels.ProductTypeGroup;
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
    [Authorize(Policy = PolicyRecorads.Recorads)]
    public class ProductTypeGroupController : ControllerBase
    {
        private readonly IProductTypeGroupService _productTypeGroupService;

        public ProductTypeGroupController(IProductTypeGroupService productTypeGroupService)
        {
            _productTypeGroupService = productTypeGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductTypeGroup request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _productTypeGroupService.Create(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }

            var result = await _productTypeGroupService.GetById(resultId.ResultObj);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProductTypeGroupPagingRequest request)
        {
            var result = await _productTypeGroupService.GetUsersPaging(request);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productTypeGroupService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _productTypeGroupService.GetById(id);
            return Ok(user);
        }

        [Authorize(Roles = ListRole.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productTypeGroupService.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductTypeGroup request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productTypeGroupService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("check-name")]
        public async Task<IActionResult> iName(string name, int? id)
        {
            var resultId = await _productTypeGroupService.iName(name, id);
            return Ok(resultId);
        }
    }
}