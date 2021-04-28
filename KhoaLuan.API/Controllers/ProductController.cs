using KhoaLuan.Service.ProductService;
using KhoaLuan.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _productService.Create(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }

            var result = await _productService.GetById(resultId.ResultObj);
            return Ok(result);
        }

        [HttpPut("image/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImage(int id, [FromForm] ImageProduct bundle)
        {
            var result = await _productService.UpdateImage(id,bundle);
            return Ok(result);
        }

        [HttpPost("pack")]
        public async Task<IActionResult> Create([FromBody] PackCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultId = await _productService.CreatePack(request);
            if (!resultId.IsSuccessed)
            {
                return BadRequest(resultId);
            }
            return Ok(resultId);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProductPagingRequest request)
        {
            var result = await _productService.GetUsersPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var result = await _productService.GetByIdProduct(id);
            return Ok(result);
        }

        [HttpGet("reminder/{id}")]
        public async Task<IActionResult> GetReminder(int id)
        {
            var result = await _productService.GetReminder(id);
            return Ok(result);
        }

        [HttpGet("pack/{id}")]
        public async Task<IActionResult> GetPack(int id)
        {
            var result = await _productService.GetPack(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            return Ok(result);
        }
        [HttpDelete("pack/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _productService.DeletePack(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            var list = await _productService.GetByUpdateProduct(id);
            return Ok(list);
        }

        [HttpPut("reminder/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReminder request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.UpdateReminder(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPut("pack/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePack request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.UpdatePack(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpGet("check-name")]
        public async Task<IActionResult> iName(string name, int? id)
        {
            var resultId = await _productService.iName(name, id);
            return Ok(resultId);
        }
        [HttpGet("check-pack")]
        public async Task<IActionResult> iNamePack(string name, int idSP, bool status, long? id)
        {
            var resultId = await _productService.iNamePack(name, idSP, status, id);
            return Ok(resultId);
        }
    }
}