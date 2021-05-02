using KhoaLuan.Data.Enums;
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
            //GroupType typeGroup;
            //switch (group)
            //{
            //    case "NguyenLieu":
            //        typeGroup = GroupType.NguyenLieu;
            //        break;

            //    case "VatLieu":
            //        typeGroup = GroupType.VatLieu;
            //        break;

            //    default:
            //        typeGroup = GroupType.NhienLieu;
            //        break;
            //}
            var result = await _orderPlanApiClient.GetMaterialsType(group);
            return Ok(result);
        }
    }
}