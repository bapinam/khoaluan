using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProductType;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class ProductTypesController : BaseController
    {
        private readonly IProductTypeApiClient _productTypeApiClient;

        public ProductTypesController(IProductTypeApiClient productTypeApiClient)
        {
            _productTypeApiClient = productTypeApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int groupType, int pageIndex = 1, int pageSize = 3)
        {
            var request = new GetProductTypePagingRequest()
            {
                Keyword = keyword,
                GroupType = groupType,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _productTypeApiClient.GetUsersPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpPost]
        public async Task<ApiResult<GetByIdListProductType>> Create(CreateProductType bundle)
        {
            var result = await _productTypeApiClient.Create(bundle);

            return result;
        }

        [HttpGet]
        public async Task<bool> iName(string name, int? id)
        {
            var data = await _productTypeApiClient.iName(name, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<GetByIdListProductType> GetById(int id)
        {
            var result = await _productTypeApiClient.GetById(id);

            var data = new GetByIdListProductType()
            {
                Code = result.ResultObj.Code,
                Name = result.ResultObj.Name,
                IdGroupType = result.ResultObj.IdGroupType,
                GroupType = result.ResultObj.GroupType
            };
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> Update(UpdateProductType bundle)
        {
            var data = await _productTypeApiClient.Update(bundle.Id, bundle);
            return data;
        }

        [HttpDelete]
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var data = await _productTypeApiClient.Delete(id);
            return data;
        }

        [HttpGet]
        public async Task<List<GetAllProductType>> GetAll()
        {
            var result = await _productTypeApiClient.GetAll();
            return result;
        }
    }
}