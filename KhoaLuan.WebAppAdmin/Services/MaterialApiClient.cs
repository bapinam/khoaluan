using KhoaLuan.ApiClient;
using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Material;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public class MaterialApiClient : BaseApiClient, IMaterialApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MaterialApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<GetByIdListMaterial>> Create(MaterialCreate bundle)
        {

            var json = JsonConvert.SerializeObject(bundle);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Material";
            var result = await Create<GetByIdListMaterial>(url, httpContent);
            return result;
        }
        public async Task<ApiResult<GetIdPackMaterial>> CreatePack(PackMaterialCreate bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Material/pack/";
            var result = await Create<GetIdPackMaterial>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<string>> UpdateImage(int id, IFormFile image)
        {
            var requestContent = new MultipartFormDataContent();

            byte[] data;
            using (var br = new BinaryReader(image.OpenReadStream()))
            {
                data = br.ReadBytes((int)image.OpenReadStream().Length);
            }
            ByteArrayContent bytes = new ByteArrayContent(data);
            requestContent.Add(bytes, "image", image.FileName);

            var url = $"/api/Material/image/"+id;
            var result = await Update<string>(url, requestContent);
            return result;
        }
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var result = await Delete($"/api/Material/" + id);
            return result;
        }
        public async Task<ApiResult<bool>> DeletePack(long id)
        {
            var result = await Delete($"/api/Material/pack/" + id);
            return result;
        }
        public async Task<ApiResult<GetByIdMaterial>> GetByIdMaterial(int id)
        {
            var url = $"/api/Material/" + $"{id}";
            var result = await GetIdAsync<GetByIdMaterial>(url);
            return result;
        }

        public async Task<ApiResult<GetMaterialReminder>> GetReminder(int id)
        {
            var url = $"/api/Material/reminder/" + $"{id}";
            var result = await GetIdAsync<GetMaterialReminder>(url);
            return result;
        }

        public async Task<ApiResult<List<GetMaterialPack>>> GetPack(int id)
        {
            var url = $"/api/Material/pack/" + $"{id}";
            var result = await GetIdListAsync<GetMaterialPack> (url);
            return result;
        }

        public async Task<ApiResult<PagedResult<MaterialVm>>> GetUsersPaging(GetMaterialPagingRequest bundle)
        {
            var url = $"/api/Material/paging?pageIndex=" +
                $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}&materialType={bundle.MaterialType}";
            var result = await GetListAsync<MaterialVm>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            var url = $"/api/Material/check-name?name=" + $"{name}&id={id}";
            var result = await iCheck(url);
            return result;
        }
        public async Task<ApiResult<bool>> iNamePack(string name, int idLoai, bool status, long? id)
        {
            var url = $"/api/Material/check-pack?name=" + $"{name}&idLoai={idLoai}&status={status}&id={id}";
            var result = await iCheck(url);
            return result;
        }
        public async Task<ApiResult<UpdateMaterialReturn>> Update(int id, MaterialUpdate bundle)
        {
            ApiResult<UpdateMaterialReturn> result;
            if(bundle.Image!=null)
            {
                var Material = new UpdateMaterialReturn()
                {
                    Id = bundle.Id,
                    Code = bundle.Code,
                    Description = bundle.Description,
                    Name = bundle.Name,
                    IdMaterialType = bundle.IdMaterialType
                };    
                var json = JsonConvert.SerializeObject(Material);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"/api/Material/" + $"{id}";
               result = await Update<UpdateMaterialReturn>(url, httpContent);

               var image =  await this.UpdateImage(id, bundle.Image);
                result.ResultObj.Image = image.ResultObj;

            }   else
            {
                var json = JsonConvert.SerializeObject(bundle);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"/api/Material/" + $"{id}";
                result = await Update<UpdateMaterialReturn>(url, httpContent);

            }
            return result;
        }

        public async Task<ApiResult<bool>> UpdateReminder(int id, UpdateMaterialReminder bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Material/reminder/" + $"{id}";
            var result = await Update<bool>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> UpdatePack(long id, UpdateMaterialPack bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Material/pack/" + $"{id}";
            var result = await Update<bool>(url, httpContent);
            return result;
        }
    }
}