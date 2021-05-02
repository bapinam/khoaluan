using KhoaLuan.Data.Enums;
using KhoaLuan.Service.RecipeService;
using KhoaLuan.ViewModels.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = PolicyRecorads.Recorads)]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetRecipePagingRequest request)
        {
            var result = await _recipeService.GetRecipePaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListRecipe(int id)
        {
            var result = await _recipeService.GetListRecipe(id);
            return Ok(result);
        }

        [HttpGet("check-name")]
        public async Task<IActionResult> iName(string name, int idSP, int? id)
        {
            var result = await _recipeService.iName(name, idSP, id);
            return Ok(result);
        }

        [HttpGet("check-materials")]
        public async Task<IActionResult> iMaterials(int idRecipe, int idMaterials)
        {
            var result = await _recipeService.iMaterials(idRecipe, idMaterials);
            return Ok(result);
        }

        [HttpGet("materials-type")]
        public async Task<IActionResult> GetMaterialsType(GroupType? group)
        {
            var result = await _recipeService.GetMaterialsType(group);
            return Ok(result);
        }

        [HttpGet("materials")]
        public async Task<IActionResult> GetListMaterials([FromQuery] ListBundleMaterials bundle)
        {
            var result = await _recipeService.GetListMaterials(bundle);
            return Ok(result);
        }

        [HttpGet("packs/{id}")]
        public async Task<IActionResult> GetListPacks(int id)
        {
            var result = await _recipeService.GetListPacks(id);
            return Ok(result);
        }

        [HttpGet("recipe/{id}")]
        public async Task<IActionResult> GetListIdRecipe(int id)
        {
            var result = await _recipeService.GetListIdRecipe(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecipe bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _recipeService.Create(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("prioritize")]
        public async Task<IActionResult> Update([FromBody] UpdatePrioritizeRecipe bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _recipeService.UpdatePrioritizeRecipe(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRecipe bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _recipeService.Update(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = ListRole.Admin)]
        [HttpDelete("{id}/{idProduct}")]
        public async Task<IActionResult> Delete(int id, int idProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _recipeService.Delete(id, idProduct);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("materials/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _recipeService.DeleteMaterials(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}