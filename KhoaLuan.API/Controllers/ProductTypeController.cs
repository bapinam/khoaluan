using KhoaLuan.Service.ProductTypeService;
using KhoaLuan.ViewModels.ProductType;
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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductType request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _productTypeService.Create(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }

            var result = await _productTypeService.GetById(resultId.ResultObj);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProductTypePagingRequest request)
        {
            var result = await _productTypeService.GetUsersPaging(request);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productTypeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _productTypeService.GetById(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productTypeService.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductType request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productTypeService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("check-name")]
        public async Task<IActionResult> iName(string name, int? id)
        {
            var resultId = await _productTypeService.iName(name, id);
            return Ok(resultId);
        }
    }
}