using KhoaLuan.ViewModels.Bill;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class BillsController : BaseController
    {
        private readonly IBillApiClient _billApiClient;

        public BillsController(IBillApiClient billApiClient)
        {
            _billApiClient = billApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
        {
            var request = new GetAllPaidBillPanning()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _billApiClient.GetAllPaidBill(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetByOrderPlanBills(string key)
        {
            var result = await _billApiClient.GetByOrderPlanBills(key);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CombinedBills(CombinedBills bundle)
        {
            var result = await _billApiClient.CombinedBills(bundle);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdOrderPlanBills(long id)
        {
            var result = await _billApiClient.GetByIdOrderPlanBills(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers(string key)
        {
            var result = await _billApiClient.GetAllSuppliers(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CancelBills(long id)
        {
            var result = await _billApiClient.CancelBills(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SplitBills(long id)
        {
            var result = await _billApiClient.SplitBills(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBill bundle)
        {
            var result = await _billApiClient.Create(bundle);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnpaidBill(string key)
        {
            var result = await _billApiClient.GetAllUnpaidBill(key);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBillById(long id)
        {
            var result = await _billApiClient.GetBillById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBill bundle)
        {
            var result = await _billApiClient.Update(bundle);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnpaid(UpdateUnpaid bundle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _billApiClient.UpdateUnpaid(bundle);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _billApiClient.Delete(id);
            return Ok(result);
        }
    }
}