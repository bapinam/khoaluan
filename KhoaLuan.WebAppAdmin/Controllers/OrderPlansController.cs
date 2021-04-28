using KhoaLuan.WebAppAdmin.Controllers.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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