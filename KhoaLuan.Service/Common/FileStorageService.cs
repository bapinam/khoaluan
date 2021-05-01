using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _productContentFolder;
        private const string PRODUCT_CONTENT_FOLDER_NAME = "product-content";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _productContentFolder = Path.Combine(webHostEnvironment.WebRootPath, PRODUCT_CONTENT_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{PRODUCT_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_productContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_productContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}