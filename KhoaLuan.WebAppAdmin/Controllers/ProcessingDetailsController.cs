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

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetProcessCompletePaging()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _processingDetailApiClient.GetProcessComplete(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
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
        public async Task<IActionResult> GetViewProcessingVocher(long id)
        {
            var result = await _processingDetailApiClient.GetViewProcessingVocher(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMarkProcessing(string key)
        {
            var result = await _processingDetailApiClient.GetMarkProcessing(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeMarkStatus(long id)
        {
            var result = await _processingDetailApiClient.ChangeMarkStatus(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CancelProcess(long id)
        {
            var result = await _processingDetailApiClient.CancelProcess(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SplitProcess(long id)
        {
            var result = await _processingDetailApiClient.SplitProcess(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProcess bundle)
        {
            var result = await _processingDetailApiClient.Create(bundle);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _processingDetailApiClient.Delete(id);
            return Ok(result);
        }
    }
}