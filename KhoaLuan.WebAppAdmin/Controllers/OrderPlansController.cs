using KhoaLuan.WebAppAdmin.Controllers.Components;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}