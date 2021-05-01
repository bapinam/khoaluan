using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Product;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhoaLuan.Utilities.Constants.SystemConstants;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    [Authorize(Roles = ListRole.Records)]
    public class ProductsController : BaseController
    {
        private readonly IProductApiClient _productApiClient;

        public ProductsController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int productType, int pageIndex = 1, int pageSize = 3)
        {
            var request = new GetProductPagingRequest()
            {
                Keyword = keyword,
                ProductType = productType,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _productApiClient.GetUsersPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ApiResult<GetByIdListProduct>> Create([FromForm] ProductCreateContent bundle)
        {
            var proudct = new ProductCreate()
            {
                Code = bundle.Code,
                Name = bundle.Name,
                Description = bundle.Description,
                IdProductType = bundle.IdProductType,
                Max = bundle.Max,
                Min = bundle.Min,
                NamePack = bundle.NamePack,
                NamePackDefault = bundle.NamePackDefault,
                Reminder = bundle.Reminder,
                ReminderEndDate = bundle.ReminderEndDate,
                ReminderStartDate = bundle.ReminderStartDate,
                ValuePack = bundle.ValuePack
            };
            var result = await _productApiClient.Create(proudct);

            if (bundle.Image != null)
            {
                var image = await _productApiClient.UpdateImage(result.ResultObj.Id, bundle.Image);
                result.ResultObj.Image = image.ResultObj;
            }
            return result;
        }

        [HttpPost]
        public async Task<GetIdPack> CreatePack(PackCreate bundle)
        {
            var result = await _productApiClient.CreatePack(bundle);
            var data = new GetIdPack()
            {
                Name = result.ResultObj.Name,
                Value = result.ResultObj.Value,
                Id = result.ResultObj.Id
            };
            return data;
        }

        [HttpGet]
        public async Task<bool> iName(string name, int? id)
        {
            var data = await _productApiClient.iName(name, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<bool> iNamePack(string name, int idSP, bool status, long? id)
        {
            var data = await _productApiClient.iNamePack(name, idSP, status, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<GetByIdProduct> GetByIdProduct(int id)
        {
            var result = await _productApiClient.GetByIdProduct(id);

            var data = new GetByIdProduct()
            {
                Id = result.ResultObj.Id,
                Code = result.ResultObj.Code,
                Name = result.ResultObj.Name,
                Image = result.ResultObj.Image,
                Description = result.ResultObj.Description,
                IdProductType = result.ResultObj.IdProductType,
                NameProductType = result.ResultObj.NameProductType,
                Amount = result.ResultObj.Amount,
                Pack = result.ResultObj.Pack,
                Reminder = result.ResultObj.Reminder,
                NamePackDefault = result.ResultObj.NamePackDefault
            };
            return data;
        }

        [HttpGet]
        public async Task<GetReminder> GetReminder(int id)
        {
            var result = await _productApiClient.GetReminder(id);

            var data = new GetReminder()
            {
                Reminder = result.ResultObj.Reminder,
                Min = result.ResultObj.Min,
                Max = result.ResultObj.Max,
                ReminderStartDate = result.ResultObj.ReminderStartDate,
                ReminderEndDate = result.ResultObj.ReminderEndDate,
            };
            return data;
        }

        [HttpGet]
        public async Task<List<GetPack>> GetPack(int id)
        {
            var result = await _productApiClient.GetPack(id);

            var data = new List<GetPack>();
            data = result.ResultObj;
            return data;
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<ApiResult<UpdateReturn>> Update([FromForm] ProductUpdate bundle)
        {
            var data = await _productApiClient.Update(bundle.Id, bundle);
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> UpdateReminder(UpdateReminder bundle)
        {
            var data = await _productApiClient.UpdateReminder(bundle.Id, bundle);
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> UpdatePack(UpdatePack bundle)
        {
            var data = await _productApiClient.UpdatePack(bundle.Id, bundle);
            return data;
        }

        [Authorize(Roles = ListRole.Admin)]
        [HttpDelete]
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var data = await _productApiClient.Delete(id);
            return data;
        }

        [HttpDelete]
        public async Task<ApiResult<bool>> DeletePack(long id)
        {
            var data = await _productApiClient.DeletePack(id);
            return data;
        }
    }
}