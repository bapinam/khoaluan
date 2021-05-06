using KhoaLuan.Data.Enums;
using KhoaLuan.Service.OrderPlanService;
using KhoaLuan.ViewModels.OrderPlan;
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
    public class OrderPlanController : ControllerBase
    {
        private readonly IOrderPlanService _orderPlanService;

        public OrderPlanController(IOrderPlanService orderPlanService)
        {
            _orderPlanService = orderPlanService;
        }

        [HttpGet("materials-type")]
        public async Task<IActionResult> GetMaterialsType(GroupType group)
        {
            var result = await _orderPlanService.GetMaterialsType(group);
            return Ok(result);
        }

        [HttpGet("materials")]
        public async Task<IActionResult> GetMaterialsSearch(int id, string key)
        {
            var result = await _orderPlanService.GetMaterialsSearch(id, key);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderPlan request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _orderPlanService.Create(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployee(string key)
        {
            var result = await _orderPlanService.GetEmployee(key);
            return Ok(result);
        }

        [HttpGet("list-suppliers")]
        public async Task<IActionResult> GetListSuppliersPlan(string key)
        {
            var result = await _orderPlanService.GetListSuppliersPlan(key);
            return Ok(result);
        }

        [HttpGet("censorship")]
        public async Task<IActionResult> GetByOrderPlanCensorship()
        {
            var result = await _orderPlanService.GetByOrderPlanCensorship();
            return Ok(result);
        }

        [HttpPut("update-censorship")]
        public async Task<IActionResult> UpdateOrderPlanCensorship(UpdateOrderPlanCensorship bundle)
        {
            var result = await _orderPlanService.UpdateOrderPlanCensorship(bundle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _orderPlanService.Delete(id);
            return Ok(result);
        }
    }
}