using KhoaLuan.Data.Enums;
using KhoaLuan.Service.OrderPlanService;
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
    }
}