using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.OrderPlan;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class OrderPlansController : BaseController
    {
        private readonly IOrderPlanApiClient _orderPlanApiClient;

        public OrderPlansController(IOrderPlanApiClient orderPlanApiClient)
        {
            _orderPlanApiClient = orderPlanApiClient;
        }

        public async Task<IActionResult> Index(string keyword, string status, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetOrderPlanPagingRequest()
            {
                Keyword = keyword,
                Status = status,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _orderPlanApiClient.GetOrderPlanPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialsType(GroupType group)
        {
            var result = await _orderPlanApiClient.GetMaterialsType(group);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialsSearch(int id, string key)
        {
            var result = await _orderPlanApiClient.GetMaterialsSearch(id, key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListPacksById(int id)
        {
            var result = await _orderPlanApiClient.GetListPacksById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderPlan bundle)
        {
            var result = await _orderPlanApiClient.Create(bundle);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployee(string key)
        {
            var result = await _orderPlanApiClient.GetEmployee(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListSuppliersPlan(string key)
        {
            var result = await _orderPlanApiClient.GetListSuppliersPlan(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByOrderPlanCensorship()
        {
            var result = await _orderPlanApiClient.GetByOrderPlanCensorship();
            return Ok(result);
        }

        //duyệt
        [HttpGet]
        public async Task<IActionResult> GetByOrderPlanApproved(string key)
        {
            var result = await _orderPlanApiClient.GetByOrderPlanApproved(key);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderPlanCensorship(UpdateOrderPlanCensorship bundle)
        {
            var result = await _orderPlanApiClient.UpdateOrderPlanCensorship(bundle);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _orderPlanApiClient.Delete(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderPlan(long id)
        {
            var result = await _orderPlanApiClient.GetOrderPlan(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderPlan bundle)
        {
            var result = await _orderPlanApiClient.Update(bundle);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdOrderPlan(long id)
        {
            var result = await _orderPlanApiClient.GetByIdOrderPlan(id);
            return Ok(result);
        }
    }
}