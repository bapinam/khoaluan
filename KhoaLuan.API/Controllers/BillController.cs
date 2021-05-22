using KhoaLuan.Service.BillService;
using KhoaLuan.ViewModels.Bill;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet("order-plan/all")]
        public async Task<IActionResult> GetByOrderPlanBills(string key)
        {
            var result = await _billService.GetByOrderPlanBills(key);
            return Ok(result);
        }

        [HttpGet("order-plan/{id}")]
        public async Task<IActionResult> GetByIdOrderPlanBills(long id)
        {
            var result = await _billService.GetByIdOrderPlanBills(id);
            return Ok(result);
        }

        [HttpGet("cance-bill/{id}")]
        public async Task<IActionResult> CancelBills(long id)
        {
            var result = await _billService.CancelBills(id);
            return Ok(result);
        }

        [HttpGet("split-bill/{id}")]
        public async Task<IActionResult> SplitBills(long id)
        {
            var result = await _billService.SplitBills(id);
            return Ok(result);
        }

        [HttpGet("suppliers/{key}")]
        public async Task<IActionResult> GetAllSuppliers(string key)
        {
            var result = await _billService.GetAllSuppliers(key);
            return Ok(result);
        }

        [HttpGet("unpaid-bill")]
        public async Task<IActionResult> GetAllUnpaidBill(string key)
        {
            var result = await _billService.GetAllUnpaidBill(key);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaidBill([FromQuery] GetAllPaidBillPanning bundle)
        {
            var result = await _billService.GetAllPaidBill(bundle);
            return Ok(result);
        }

        [HttpGet("id-bill/{id}")]
        public async Task<IActionResult> GetBillById(long id)
        {
            var result = await _billService.GetBillById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBill bundle)
        {
            var resultId = await _billService.Create(bundle);
            if (!resultId.IsSuccessed)
            {
                return BadRequest();
            }

            var result = await _billService.GetBillById(resultId.ResultObj);
            return Ok(result);
        }

        [HttpPost("combined-bills")]
        public async Task<IActionResult> CombinedBills([FromBody] CombinedBills bundle)
        {
            var result = await _billService.CombinedBills(bundle);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBill bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _billService.Update(bundle);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("unpaid")]
        public async Task<IActionResult> UpdateUnpaid(UpdateUnpaid bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _billService.UpdateUnpaid(bundle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _billService.Delete(id);
            return Ok(result);
        }
    }
}