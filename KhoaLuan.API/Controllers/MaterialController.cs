using KhoaLuan.Service.MaterialService;
using KhoaLuan.ViewModels.Material;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaterialCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _materialService.Create(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }

            var result = await _materialService.GetById(resultId.ResultObj);
            return Ok(result);
        }

        [HttpPut("image/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImage(int id, [FromForm] ImageMaterial bundle)
        {
            var result = await _materialService.UpdateImage(id,bundle);
            return Ok(result);
        }

        [HttpPost("pack")]
        public async Task<IActionResult> Create([FromBody] PackMaterialCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _materialService.CreatePack(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }
            return Ok(resultId);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetMaterialPagingRequest request)
        {
            var result = await _materialService.GetUsersPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMaterial(int id)
        {
            var result = await _materialService.GetByIdMaterial(id);
            return Ok(result);
        }

        [HttpGet("reminder/{id}")]
        public async Task<IActionResult> GetReminder(int id)
        {
            var result = await _materialService.GetReminder(id);
            return Ok(result);
        }

        [HttpGet("pack/{id}")]
        public async Task<IActionResult> GetPack(int id)
        {
            var result = await _materialService.GetPack(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _materialService.Delete(id);
            return Ok(result);
        }
        [HttpDelete("pack/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _materialService.DeletePack(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaterialUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _materialService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            var list = await _materialService.GetByUpdateMaterial(id);
            return Ok(list);
        }

        [HttpPut("reminder/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMaterialReminder request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _materialService.UpdateReminder(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPut("pack/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateMaterialPack request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _materialService.UpdatePack(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpGet("check-name")]
        public async Task<IActionResult> iName(string name, int? id)
        {
            var resultId = await _materialService.iName(name, id);
            return Ok(resultId);
        }
        [HttpGet("check-pack")]
        public async Task<IActionResult> iNamePack(string name, int idLoai, bool status, long? id)
        {
            var resultId = await _materialService.iNamePack(name, idLoai, status, id);
            return Ok(resultId);
        }
    }
}