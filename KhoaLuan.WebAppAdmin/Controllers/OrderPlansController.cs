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

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderPlan bundle)
        {
            var result = await _orderPlanApiClient.Create(bundle);
            return Ok(result);
        }

        [HttpGet]
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
    }
}