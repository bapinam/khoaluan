using KhoaLuan.ViewModels.ProcessPlan;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class ProcessPlansController : BaseController
    {
        private readonly IProcessPlanApiClient _processPlanApiClient;

        public ProcessPlansController(IProcessPlanApiClient processPlanApiClient)
        {
            _processPlanApiClient = processPlanApiClient;
        }

        public async Task<IActionResult> Index(string keyword, string status, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetProcessPlanPagingRequest()
            {
                Keyword = keyword,
                Status = status,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _processPlanApiClient.GetProcessPlanPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductGroup()
        {
            var result = await _processPlanApiClient.GetAllProductGroup();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductType(int id)
        {
            var result = await _processPlanApiClient.GetAllProductType(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductRecipes(int id, string key)
        {
            var result = await _processPlanApiClient.GetAllProductRecipes(id, key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(string key)
        {
            var result = await _processPlanApiClient.GetEmployee(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListPacksById(int id)
        {
            var result = await _processPlanApiClient.GetListPacksById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListPacksProduct(int id)
        {
            var result = await _processPlanApiClient.GetListPacksProduct(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByProcessPlanApproved(string key)
        {
            var result = await _processPlanApiClient.GetByProcessPlanApproved(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByProcessPlanCensorship()
        {
            var result = await _processPlanApiClient.GetByProcessPlanCensorship();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessPlanById(long id)
        {
            var result = await _processPlanApiClient.GetProcessPlanById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialsByRecipes(int idRecipe)
        {
            var result = await _processPlanApiClient.GetMaterialsByRecipes(idRecipe);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessPlanByIdRecipes(long id)
        {
            var result = await _processPlanApiClient.GetProcessPlanByIdRecipes(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlan bundle)
        {
            var result = await _processPlanApiClient.Create(bundle);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePlan bundle)
        {
            var result = await _processPlanApiClient.Update(bundle);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProcessPlanCensorship(UpdateCensorship bundle)
        {
            var result = await _processPlanApiClient.UpdateProcessPlanCensorship(bundle);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _processPlanApiClient.Delete(id);
            return Ok(result);
        }
    }
}