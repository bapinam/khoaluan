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

        public IActionResult Index()
        {
            return View();
        }
    }
}