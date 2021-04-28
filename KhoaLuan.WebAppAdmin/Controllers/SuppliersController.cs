using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Supplier;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly ISupplierApiClient _supplierApiClient;

        public SuppliersController(ISupplierApiClient supplierApiClient)
        {
            _supplierApiClient = supplierApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 1)
        {
            var request = new GetSupplierPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _supplierApiClient.GetUsersPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpPost]
        public async Task<ApiResult<GetByIdListSupplier>> Create(SupplierCreate bundle)
        {
            var result = await _supplierApiClient.Create(bundle);

            return result;
        }

        [HttpGet]
        public async Task<bool> iTax(string tax, int? id)
        {
            var data = await _supplierApiClient.iTax(tax, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<bool> iEmail(string email, int? id)
        {
            var data = await _supplierApiClient.iEmail(email, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<GetByIdListSupplier> GetById(int id)
        {
            var result = await _supplierApiClient.GetById(id);

            var data = new GetByIdListSupplier()
            {
                Code = result.ResultObj.Code,
                Tax = result.ResultObj.Tax,
                Name = result.ResultObj.Name,
                Phone = result.ResultObj.Phone,
                Address = result.ResultObj.Address,
                Email = result.ResultObj.Email
            };
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> Update(SupplierUpdate bundle)
        {
            var data = await _supplierApiClient.Update(bundle.Id, bundle);
            return data;
        }

        [HttpDelete]
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var data = await _supplierApiClient.Delete(id);
            return data;
        }
    }
}