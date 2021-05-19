using KhoaLuan.Service.ProcessPlanService;
using KhoaLuan.ViewModels.ProcessPlan;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPlanController : ControllerBase
    {
        private readonly IProcessPlanService _processPlanService;

        public ProcessPlanController(IProcessPlanService processPlanService)
        {
            _processPlanService = processPlanService;
        }

        [HttpGet("product-group")]
        public async Task<IActionResult> GetAllProductGroup()
        {
            var result = await _processPlanService.GetAllProductGroup();
            return Ok(result);
        }

        [HttpGet("product-type/{id}")]
        public async Task<IActionResult> GetAllProductType(int id)
        {
            var result = await _processPlanService.GetAllProductType(id);
            return Ok(result);
        }

        [HttpGet("product-recipes/{id}/{key}")]
        public async Task<IActionResult> GetAllProductRecipes(int id, string key)
        {
            var result = await _processPlanService.GetAllProductRecipes(id, key);
            return Ok(result);
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployee(string key)
        {
            var result = await _processPlanService.GetEmployee(key);
            return Ok(result);
        }

        [HttpGet("materials-recipe/{idRecipe}")]
        public async Task<IActionResult> GetMaterialsByRecipes(int idRecipe)
        {
            var result = await _processPlanService.GetMaterialsByRecipes(idRecipe);
            return Ok(result);
        }

        [HttpGet("pack/{id}")]
        public async Task<IActionResult> GetListPacksById(int id)
        {
            var result = await _processPlanService.GetListPacksById(id);
            return Ok(result);
        }

        [HttpGet("pack-product/{id}")]
        public async Task<IActionResult> GetListPacksProduct(int id)
        {
            var result = await _processPlanService.GetListPacksProduct(id);
            return Ok(result);
        }

        [HttpGet("approved/{key}")]
        public async Task<IActionResult> GetByProcessPlanApproved(string key)
        {
            var result = await _processPlanService.GetByProcessPlanApproved(key);
            return Ok(result);
        }

        [HttpGet("censorship")]
        public async Task<IActionResult> GetByProcessPlanCensorship()
        {
            var result = await _processPlanService.GetByProcessPlanCensorship();
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProcessPlanPagingRequest request)
        {
            var result = await _processPlanService.GetProcessPlanPaging(request);
            return Ok(result);
        }

        [HttpGet("process-plan-id/{id}")]
        public async Task<IActionResult> GetProcessPlanById(long id)
        {
            var result = await _processPlanService.GetProcessPlanById(id);
            return Ok(result);
        }

        [HttpGet("process-plan-id-recipes/{id}")]
        public async Task<IActionResult> GetProcessPlanByIdRecipes(long id)
        {
            var result = await _processPlanService.GetProcessPlanByIdRecipes(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlan bundle)
        {
            var result = await _processPlanService.Create(bundle);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePlan bundle)
        {
            var resultId = await _processPlanService.Update(bundle);

            if (resultId.IsSuccessed)
            {
                var result = await _processPlanService.GetProcessPlanById(resultId.ResultObj);
                return Ok(result);
            }

            return BadRequest(resultId);
        }

        [HttpPut("censorship")]
        public async Task<IActionResult> Update([FromBody] UpdateCensorship bundle)
        {
            var result = await _processPlanService.UpdateProcessPlanCensorship(bundle);

            if (result.IsSuccessed)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _processPlanService.Delete(id);
            return Ok(result);
        }
    }
}