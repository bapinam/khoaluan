using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.MaterialsType;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
using KhoaLuan.WebAppAdmin.Controllers.Components;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Controllers
{
    public class MaterialsTypesController : BaseController
    {
        private readonly IMaterialsTypeApiClient _materialsTypeApiClient;

        public MaterialsTypesController(IMaterialsTypeApiClient materialsTypeApiClient)
        {
            _materialsTypeApiClient = materialsTypeApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 1)
        {
            var request = new GetMaterialsTypePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _materialsTypeApiClient.GetUsersPaging(request);

            ViewBag.Keyword = keyword;

            return View(data.ResultObj);
        }

        [HttpPost]
        public async Task<ApiResult<GetByIdListMaterialsType>> Create(CreateMaterialsType bundle)
        {
            var result = await _materialsTypeApiClient.Create(bundle);

            return result;
        }

        [HttpGet]
        public async Task<bool> iName(string name, int? id)
        {
            var data = await _materialsTypeApiClient.iName(name, id);
            return data.IsSuccessed;
        }

        [HttpGet]
        public async Task<GetByIdListMaterialsType> GetById(int id)
        {
            var result = await _materialsTypeApiClient.GetById(id);

            var data = new GetByIdListMaterialsType()
            {
                Code = result.ResultObj.Code,
                Name = result.ResultObj.Name,
                GroupType = result.ResultObj.GroupType
            };
            return data;
        }

        [HttpPut]
        public async Task<ApiResult<bool>> Update(UpdateMaterialsType bundle)
        {
            var data = await _materialsTypeApiClient.Update(bundle.Id, bundle);
            return data;
        }

        [HttpDelete]
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var data = await _materialsTypeApiClient.Delete(id);
            return data;
        }


        [HttpGet]
        public async Task<List<GetAllMaterialsType>> GetAll()
        {
            var result = await _materialsTypeApiClient.GetAll();
            return result;
        }
    }
}