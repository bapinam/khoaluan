using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProductTypeGroup;
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
    [Authorize(Policy = PolicyRecorads.Recorads)]
    public class ProductTypeGroupsController : BaseController
    {
        private readonly IProductTypeGroupApiClient _productTypeGroupApiClient;

        public ProductTypeGroupsController(IProductTypeGroupApiClient productTypeGroupApiClient)
        {
            _productTypeGroupApiClient = productTypeGroupApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 1)
        {
            var request = new GetProductTypeGroupPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _productTypeGroupApiClient.GetUsersPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpPost]
        public async Task<ApiResult<GetByIdListProductTypeGroup>> Create(CreateProductTypeGroup bundle)
        {
            var result = await _productTypeGroupApiClient.Create(bundle);

            return result;
        }

        [HttpGet]
        public async Task<bool> iName(string name, int? id)
        {
            var data = await _productTypeGroupApiClient.iName(name, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<GetByIdListProductTypeGroup> GetById(int id)
        {
            var result = await _productTypeGroupApiClient.GetById(id);

            var data = new GetByIdListProductTypeGroup()
            {
                Code = result.ResultObj.Code,
                Name = result.ResultObj.Name
            };
            return data;
        }

        [HttpGet]
        public async Task<List<GetAllProductTypeGroup>> GetAll()
        {
            var result = await _productTypeGroupApiClient.GetAll();
            return result;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> Update(UpdateProductTypeGroup bundle)
        {
            var data = await _productTypeGroupApiClient.Update(bundle.Id, bundle);
            return data;
        }

        [Authorize(Roles = ListRole.Admin)]
        [HttpDelete]
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var data = await _productTypeGroupApiClient.Delete(id);
            return data;
        }
    }
}