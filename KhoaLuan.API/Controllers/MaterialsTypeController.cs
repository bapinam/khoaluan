using KhoaLuan.Service;
using KhoaLuan.Service.MaterialsTypeService;
using KhoaLuan.ViewModels;
using KhoaLuan.ViewModels.MaterialsType;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
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
    [Authorize(Roles = ListRole.Records)]
    public class MaterialsTypeController : ControllerBase
    {
        private readonly IMaterialsTypeService _materialsTypeService;

        public MaterialsTypeController(IMaterialsTypeService materialsTypeService)
        {
            _materialsTypeService = materialsTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMaterialsType request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _materialsTypeService.Create(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }

            var result = await _materialsTypeService.GetById(resultId.ResultObj);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetMaterialsTypePagingRequest request)
        {
            var result = await _materialsTypeService.GetUsersPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _materialsTypeService.GetById(id);
            return Ok(user);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _materialsTypeService.GetAll();
            return Ok(result);
        }

        [Authorize(Roles = ListRole.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _materialsTypeService.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMaterialsType request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _materialsTypeService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("check-name")]
        public async Task<IActionResult> iName(string name, int? id)
        {
            var resultId = await _materialsTypeService.iName(name, id);
            return Ok(resultId);
        }
    }
}