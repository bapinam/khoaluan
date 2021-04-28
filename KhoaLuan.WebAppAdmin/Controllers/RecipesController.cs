using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Recipe;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class RecipesController : BaseController
    {
        private readonly IRecipeApiClient _recipeApiClient;

        public RecipesController(IRecipeApiClient recipeApiClient)
        {
            _recipeApiClient = recipeApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int productType, int pageIndex = 1, int pageSize = 3)
        {
            var request = new GetRecipePagingRequest()
            {
                Keyword = keyword,
                ProductType = productType,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _recipeApiClient.GetRecipePaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<List<GetListRecipe>> GetListRecipe(int id)
        {
            var result = await _recipeApiClient.GetListRecipe(id);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetListIdRecipe(int id)
        {
            var result = await _recipeApiClient.GetListIdRecipe(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> iName(string name, int idSP, int? id)
        {
            var result = await _recipeApiClient.iName(name, idSP, id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> iMaterials(int idRecipe, int idMaterials)
        {
            var result = await _recipeApiClient.iMaterials(idRecipe, idMaterials);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialsType(GroupType? group)
        {
            var result = await _recipeApiClient.GetMaterialsType(group);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListMaterials(ListBundleMaterials bundle)
        {
            var result = await _recipeApiClient.GetListMaterials(bundle);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListPacks(int id)
        {
            var result = await _recipeApiClient.GetListPacks(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipe bundle)
        {
            var result = await _recipeApiClient.CreateRecipe(bundle);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrioritizeRecipe(UpdatePrioritizeRecipe bundle)
        {
            var result = await _recipeApiClient.UpdatePrioritizeRecipe(bundle);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRecipe bundle)
        {
            var result = await _recipeApiClient.Update(bundle);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, int idProduct)
        {
            var result = await _recipeApiClient.Delete(id, idProduct);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaterials(long id)
        {
            var result = await _recipeApiClient.DeleteMaterials(id);
            return Ok(result);
        }
    }
}