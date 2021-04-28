using KhoaLuan.ApiClient;
using KhoaLuan.ApiClient.Common;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Product;
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
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<GetByIdListProduct>> Create(ProductCreate bundle)
        {

            var json = JsonConvert.SerializeObject(bundle);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Product";
            var result = await Create<GetByIdListProduct>(url, httpContent);
            return result;
        }
        public async Task<ApiResult<GetIdPack>> CreatePack(PackCreate bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/Product/pack/";
            var result = await Create<GetIdPack>(url, httpContent);
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

            var url = $"/api/Product/image/"+id;
            var result = await Update<string>(url, requestContent);
            return result;
        }
        public async Task<ApiResult<bool>> Delete(int id)
        {
            var result = await Delete($"/api/Product/" + id);
            return result;
        }
        public async Task<ApiResult<bool>> DeletePack(long id)
        {
            var result = await Delete($"/api/Product/pack/" + id);
            return result;
        }
        public async Task<ApiResult<GetByIdProduct>> GetByIdProduct(int id)
        {
            var url = $"/api/product/" + $"{id}";
            var result = await GetIdAsync<GetByIdProduct>(url);
            return result;
        }

        public async Task<ApiResult<GetReminder>> GetReminder(int id)
        {
            var url = $"/api/product/reminder/" + $"{id}";
            var result = await GetIdAsync<GetReminder>(url);
            return result;
        }

        public async Task<ApiResult<List<GetPack>>> GetPack(int id)
        {
            var url = $"/api/product/pack/" + $"{id}";
            var result = await GetIdListAsync<GetPack> (url);
            return result;
        }

        public async Task<ApiResult<PagedResult<ProductVm>>> GetUsersPaging(GetProductPagingRequest bundle)
        {
            var url = $"/api/Product/paging?pageIndex=" +
                $"{bundle.PageIndex}&pageSize={bundle.PageSize}&keyword={bundle.Keyword}&productType={bundle.ProductType}";
            var result = await GetListAsync<ProductVm>(url);
            return result;
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            var url = $"/api/Product/check-name?name=" + $"{name}&id={id}";
            var result = await iCheck(url);
            return result;
        }
        public async Task<ApiResult<bool>> iNamePack(string name, int idSP, bool status, long? id)
        {
            var url = $"/api/Product/check-pack?name=" + $"{name}&idSP={idSP}&status={status}&id={id}";
            var result = await iCheck(url);
            return result;
        }
        public async Task<ApiResult<UpdateReturn>> Update(int id, ProductUpdate bundle)
        {
            ApiResult<UpdateReturn> result;
            if(bundle.Image!=null)
            {
                var product = new UpdateReturn()
                {
                    Id = bundle.Id,
                    Code = bundle.Code,
                    Description = bundle.Description,
                    Name = bundle.Name,
                    IdProductType = bundle.IdProductType
                };    
                var json = JsonConvert.SerializeObject(product);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"/api/product/" + $"{id}";
               result = await Update<UpdateReturn>(url, httpContent);

               var image =  await this.UpdateImage(id, bundle.Image);
                result.ResultObj.Image = image.ResultObj;

            }   else
            {
                var json = JsonConvert.SerializeObject(bundle);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"/api/product/" + $"{id}";
                result = await Update<UpdateReturn>(url, httpContent);

            }
            return result;
        }

        public async Task<ApiResult<bool>> UpdateReminder(int id, UpdateReminder bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/product/reminder/" + $"{id}";
            var result = await Update<bool>(url, httpContent);
            return result;
        }

        public async Task<ApiResult<bool>> UpdatePack(long id, UpdatePack bundle)
        {
            var json = JsonConvert.SerializeObject(bundle);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"/api/product/pack/" + $"{id}";
            var result = await Update<bool>(url, httpContent);
            return result;
        }
    }
}