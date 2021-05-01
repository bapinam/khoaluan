using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Material;
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
    public class MaterialsController : BaseController
    {
        private readonly IMaterialApiClient _materialApiClient;

        public MaterialsController(IMaterialApiClient materialApiClient)
        {
            _materialApiClient = materialApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int materialType, int pageIndex = 1, int pageSize = 3)
        {
            var request = new GetMaterialPagingRequest()
            {
                Keyword = keyword,
                MaterialType = materialType,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _materialApiClient.GetUsersPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ApiResult<GetByIdListMaterial>> Create([FromForm] MaterialCreateContent bundle)
        {
            var proudct = new MaterialCreate()
            {
                Code = bundle.Code,
                Name = bundle.Name,
                Description = bundle.Description,
                IdMaterialType = bundle.IdMaterialType,
                Max = bundle.Max,
                Min = bundle.Min,
                NamePack = bundle.NamePack,
                NamePackDefault = bundle.NamePackDefault,
                Reminder = bundle.Reminder,
                ReminderEndDate = bundle.ReminderEndDate,
                ReminderStartDate = bundle.ReminderStartDate,
                ValuePack = bundle.ValuePack
            };
            var result = await _materialApiClient.Create(proudct);

            if (bundle.Image != null)
            {
                var image = await _materialApiClient.UpdateImage(result.ResultObj.Id, bundle.Image);
                result.ResultObj.Image = image.ResultObj;
            }
            return result;
        }

        [HttpPost]
        public async Task<GetIdPackMaterial> CreatePack(PackMaterialCreate bundle)
        {
            var result = await _materialApiClient.CreatePack(bundle);
            var data = new GetIdPackMaterial()
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
            var data = await _materialApiClient.iName(name, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<bool> iNamePack(string name, int idLoai, bool status, long? id)
        {
            var data = await _materialApiClient.iNamePack(name, idLoai, status, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<GetByIdMaterial> GetByIdMaterial(int id)
        {
            var result = await _materialApiClient.GetByIdMaterial(id);

            var data = new GetByIdMaterial()
            {
                Id = result.ResultObj.Id,
                Code = result.ResultObj.Code,
                Name = result.ResultObj.Name,
                Image = result.ResultObj.Image,
                Description = result.ResultObj.Description,
                IdMaterialType = result.ResultObj.IdMaterialType,
                NameMaterialType = result.ResultObj.NameMaterialType,
                Amount = result.ResultObj.Amount,
                Pack = result.ResultObj.Pack,
                Reminder = result.ResultObj.Reminder,
                NamePackDefault = result.ResultObj.NamePackDefault
            };
            return data;
        }

        [HttpGet]
        public async Task<GetMaterialReminder> GetReminder(int id)
        {
            var result = await _materialApiClient.GetReminder(id);

            var data = new GetMaterialReminder()
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
        public async Task<List<GetMaterialPack>> GetPack(int id)
        {
            var result = await _materialApiClient.GetPack(id);

            var data = new List<GetMaterialPack>();
            data = result.ResultObj;
            return data;
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<ApiResult<UpdateMaterialReturn>> Update([FromForm] MaterialUpdate bundle)
        {
            var data = await _materialApiClient.Update(bundle.Id, bundle);
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> UpdateReminder(UpdateMaterialReminder bundle)
        {
            var data = await _materialApiClient.UpdateReminder(bundle.Id, bundle);
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> UpdatePack(UpdateMaterialPack bundle)
        {
            var data = await _materialApiClient.UpdatePack(bundle.Id, bundle);
            return data;
        }

        [Authorize(Roles = ListRole.Admin)]
        [HttpDelete]
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var data = await _materialApiClient.Delete(id);
            return data;
        }

        [HttpDelete]
        public async Task<ApiResult<bool>> DeletePack(long id)
        {
            var data = await _materialApiClient.DeletePack(id);
            return data;
        }
    }
}