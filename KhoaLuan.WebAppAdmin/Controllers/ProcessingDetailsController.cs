using KhoaLuan.ViewModels.ProcessingDetail;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class ProcessingDetailsController : BaseController
    {
        private readonly IProcessingDetailApiClient _processingDetailApiClient;

        public ProcessingDetailsController(IProcessingDetailApiClient processingDetailApiClient)
        {
            _processingDetailApiClient = processingDetailApiClient;
        }

        public async Task<IActionResult> Index(/*string keyword, int pageIndex = 1, int pageSize = 5*/)
        {
            //var request = new GetDistributingPagingRequest()
            //{
            //    Keyword = keyword,
            //    PageIndex = pageIndex,
            //    PageSize = pageSize
            //};
            //var data = await _processingDetailApiClient.GetDistributing(request);

            //ViewBag.Keyword = keyword;

            //return View(data.ResultObj);
            return View();
        }

        public async Task<IActionResult> GetDistributing(string key)
        {
            var data = await _processingDetailApiClient.GetDistributing(key);

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProcessDetailById(long id)
        {
            var result = await _processingDetailApiClient.GetAllProcessDetailById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CancelProcess(long id)
        {
            var result = await _processingDetailApiClient.CancelProcess(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProcess bundle)
        {
            var result = await _processingDetailApiClient.Create(bundle);
            return Ok(result);
        }
    }
}