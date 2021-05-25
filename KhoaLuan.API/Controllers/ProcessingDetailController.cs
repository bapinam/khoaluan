using KhoaLuan.Service.ProcessingDetailService;
using KhoaLuan.ViewModels.ProcessingDetail;
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
    public class ProcessingDetailController : ControllerBase
    {
        private readonly IProcessingDetailService _processingDetailService;

        public ProcessingDetailController(IProcessingDetailService processingDetailService)
        {
            _processingDetailService = processingDetailService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetProcessComplete([FromQuery] GetProcessCompletePaging bundle)
        {
            var result = await _processingDetailService.GetProcessComplete(bundle);
            return Ok(result);
        }

        [HttpGet("distributing")]
        public async Task<IActionResult> GetDistributing(string key)
        {
            var result = await _processingDetailService.GetDistributing(key);
            return Ok(result);
        }

        [HttpGet("mark")]
        public async Task<IActionResult> GetMarkProcessing(string key)
        {
            var result = await _processingDetailService.GetMarkProcessing(key);
            return Ok(result);
        }

        [HttpGet("process-detail-by/{id}")]
        public async Task<IActionResult> GetAllProcessDetailById(long id)
        {
            var result = await _processingDetailService.GetAllProcessDetailById(id);
            return Ok(result);
        }

        [HttpGet("view-vocher/{id}")]
        public async Task<IActionResult> GetViewProcessingVocher(long id)
        {
            var result = await _processingDetailService.GetViewProcessingVocher(id);
            return Ok(result);
        }

        [HttpGet("change-mark/{id}")]
        public async Task<IActionResult> ChangeMarkStatus(long id)
        {
            var result = await _processingDetailService.ChangeMarkStatus(id);
            return Ok(result);
        }

        [HttpGet("split-process/{id}")]
        public async Task<IActionResult> SplitProcess(long id)
        {
            var result = await _processingDetailService.SplitProcess(id);
            return Ok(result);
        }

        [HttpGet("cance-process/{id}")]
        public async Task<IActionResult> CancelProcess(long id)
        {
            var result = await _processingDetailService.CancelProcess(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProcess bundle)
        {
            var result = await _processingDetailService.Create(bundle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _processingDetailService.Delete(id);
            return Ok(result);
        }
    }
}