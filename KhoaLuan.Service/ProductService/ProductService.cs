using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.Service.Common;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private const string PRODUCT_CONTENT_FOLDER_NAME = SystemConstants.ImageFolder;

        public ProductService(EnterpriseDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<ApiResult<int>> Create(ProductCreate bundle)
        {
            var pack = new List<Pack>();
            pack.Add(new Pack()
            {
                Name = bundle.NamePackDefault,
                Value = 1,
                PackType = PackType.Product,
                Default = true
            });

            if (bundle.NamePack != null)
            {
                int i = 0;
                foreach (string item in bundle.NamePack)
                {
                    pack.Add(new Pack()
                    {
                        Name = item,
                        Value = bundle.ValuePack[i],
                        PackType = PackType.Product,
                        Default = false
                    });
                    i++;
                }
            }

            var product = new Product()
            {
                Code = bundle.Code,
                Name = bundle.Name,
                Description = bundle.Description,
                IdProductType = bundle.IdProductType,
                Packs = pack
            };

            if (bundle.Min != null && bundle.Max != null)
            {
                product.Reminder = true;
                product.Min = bundle.Min;
                product.Max = bundle.Max;
                product.ReminderStartDate = (DateTime)bundle.ReminderStartDate;
                product.ReminderEndDate = (DateTime)bundle.ReminderEndDate;
            }

            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var checkCode = await _context.Products.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            product.Code = str;

            _context.Products.Add(product);
            await _context.SaveChangesAsync(); // số bản ghi nếu return

            return new ApiSuccessResult<int>(product.Id);
        }

        public async Task<ApiResult<GetIdPack>> CreatePack(PackCreate bundle)
        {
            var pack = new Pack()
            {
                Name = bundle.Name,
                Value = bundle.Value,
                Default = false,
                IdProduct = bundle.IdProduct
            };
            _context.Packs.Add(pack);
            await _context.SaveChangesAsync();

            var result = new GetIdPack()
            {
                Name = pack.Name,
                Value = pack.Value,
                Id = pack.Id
            };
            return new ApiSuccessResult<GetIdPack>(result);
        }

        public async Task<ApiResult<string>> UpdateImage(int id, ImageProduct bundle)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<string>("Sản phẩm không tồn tại");
            }
            // xóa ảnh củ
            if (product.Image != null)
            {
                await _storageService.DeleteFileAsync(product.Image);
            }

            // lưu lại ảnh mới
            product.Image = await this.SaveFile(bundle.Image);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<string>(product.Image);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var product = await _context.Products.Include(x => x.Packs)
                .FirstAsync(x => x.Id == id);
            if (product == null)
            {
                return new ApiErrorResult<bool>("Sản phẩmkhông tồn tại");
            }

            if (product.Image != null)
            {
                await _storageService.DeleteFileAsync(product.Image);
            }

            var reult = _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DeletePack(long id)
        {
            var pack = await _context.Packs.FindAsync(id);
            if (pack == null)
            {
                return new ApiErrorResult<bool>("Đóng gói không tồn tại");
            }

            var reult = _context.Packs.Remove(pack);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<int>> Update(int id, ProductUpdate bundle)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<int>("Sản phẩm không tồn tại");
            }

            product.IdProductType = bundle.IdProductType;
            product.Name = bundle.Name;
            product.Description = bundle.Description;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(product.Id);
        }

        public async Task<ApiResult<bool>> UpdateReminder(UpdateReminder bundle)
        {
            var product = await _context.Products.FindAsync(bundle.Id);
            if (product == null)
            {
                return new ApiErrorResult<bool>("Sản phẩm không tồn tại");
            }

            if (bundle.BoolReminder)
            {
                product.Reminder = true;
                product.Min = bundle.Min;
                product.Max = bundle.Max;

                var str = bundle.DateReminder.Split(" - ");
                product.ReminderStartDate = Convert.ToDateTime(str[0]);
                product.ReminderEndDate = Convert.ToDateTime(str[1]);
            }
            else
            {
                product.Reminder = false;
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<ProductVm>>> GetUsersPaging(GetProductPagingRequest bundle)
        {
            var query = from s in _context.Products
                        join g in _context.ProductTypes on s.IdProductType equals g.Id
                        join d in _context.Packs on s.Id equals d.IdProduct
                        where d.Default == true

                        select new { s, g, d };

            if (bundle.ProductType > 0)
            {
                query = query.Where(x => x.g.Id == bundle.ProductType);
            }

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.s.Name.Contains(bundle.Keyword) || c.s.Code.Contains(bundle.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.s.Id);
            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(i => new ProductVm()
                {
                    Id = i.s.Id,
                    Code = i.s.Code,
                    Name = i.s.Name,
                    Image = i.s.Image,
                    Amount = i.s.Amount,
                    Reminder = i.s.Reminder,
                    NamePackDefault = i.d.Name,
                    NameProductType = i.g.Name,
                    AmountPercent = i.s.Max != null ? (int)(((double)i.s.Amount / (double)i.s.Max) * 100) : 0
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProductVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            if (id != null)
            {
                var count = await _context.Products
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(), SystemConstants.Collate_AS)
                    == name.ToUpper().Trim() && c.Id != id);
                if (count)
                {
                    return new ApiErrorResult<bool>("Tên sản phẩm đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                var count = await _context.Products
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                    SystemConstants.Collate_AS) == name.ToUpper().Trim());

                if (count)
                {
                    return new ApiErrorResult<bool>("Tên sản phẩm đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }

        public async Task<ApiResult<bool>> iNamePack(string name, int idSP, bool status, long? id)
        {
            bool count;
            if (id == null)
            {
                if (status)
                {
                    count = await _context.Packs.Where(x => x.IdProduct == idSP)
                   .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                   SystemConstants.Collate_AS) == name.ToUpper().Trim());
                }
                else
                {
                    count = await _context.Packs
                  .Where(x => x.IdProduct == idSP && x.Default != true)
                  .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                  SystemConstants.Collate_AS) == name.ToUpper().Trim());
                }
            }
            else
            {
                count = await _context.Packs
               .Where(x => x.IdProduct == idSP && x.Id != id)
               .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
               SystemConstants.Collate_AS) == name.ToUpper().Trim());
            }

            if (count)
            {
                return new ApiErrorResult<bool>("Tên đóng gói đã tồn tại");
            }
            else
            {
                return new ApiSuccessResult<bool>();
            }
        }

        public async Task<ApiResult<GetByIdListProduct>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<GetByIdListProduct>("Sản phẩm không tồn tại");
            }
            var query = await (from s in _context.Products
                               join g in _context.ProductTypes on s.IdProductType equals g.Id
                               join d in _context.Packs on s.Id equals d.IdProduct
                               where d.Default == true && s.Id == id
                               select new { s, g, d }).FirstAsync();

            var result = new GetByIdListProduct()
            {
                Id = query.s.Id,
                Code = query.s.Code,
                Name = query.s.Name,
                Image = query.s.Image,
                Amount = query.s.Amount,
                Reminder = query.s.Reminder,
                NamePackDefault = query.d.Name,
                NameProductType = query.g.Name,
                AmountPercent = query.s.Max != null ? (int)(query.s.Amount / query.s.Max * 100) : 0
            };

            return new ApiSuccessResult<GetByIdListProduct>(result);
        }

        public async Task<ApiResult<GetByIdProduct>> GetByIdProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<GetByIdProduct>("Sản phẩm không tồn tại");
            }

            var query = await (from s in _context.Products
                               join g in _context.ProductTypes on s.IdProductType equals g.Id
                               join d in _context.Packs on s.Id equals d.IdProduct
                               where s.Id == id
                               select new { s, g, d }).FirstAsync();

            var result = new GetByIdProduct()
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Image = product.Image,
                IdProductType = product.IdProductType,
                NameProductType = query.g.Name,
                Description = product.Description,
                Amount = product.Amount,
                Reminder = product.Reminder
            };

            result.NamePackDefault = query.s.Packs.Where(x => x.Default == true).Select(x => x.Name).First();

            var pack = from s in _context.Products
                       join d in _context.Packs on s.Id equals d.IdProduct
                       where s.Id == id && d.Default != true
                       select new { s, d };

            result.Pack = pack.Select(
                i => new GetPack()
                {
                    Name = i.d.Name,
                    Value = i.d.Value,
                    Default = i.d.Default,
                    Change = (long)(result.Amount / i.d.Value)
                }
                ).ToList();
            return new ApiSuccessResult<GetByIdProduct>(result);
        }

        public async Task<ApiResult<UpdateReturn>> GetByUpdateProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<UpdateReturn>("Sản phẩm không tồn tại");
            }

            var query = await (from s in _context.Products
                               join g in _context.ProductTypes on s.IdProductType equals g.Id
                               where s.Id == id
                               select new { g.Name }).FirstAsync();

            var result = new UpdateReturn()
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Image = product.Image,
                NameProductType = query.Name,
                Description = product.Description
            };

            return new ApiSuccessResult<UpdateReturn>(result);
        }

        public async Task<ApiResult<GetReminder>> GetReminder(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<GetReminder>("Sản phẩm không tồn tại");
            }

            var result = new GetReminder()
            {
                Reminder = product.Reminder,
                Min = product.Min,
                Max = product.Max,
                ReminderStartDate = product.ReminderStartDate.ToString("MM/dd/yyyy"),
                ReminderEndDate = product.ReminderEndDate.ToString("MM/dd/yyyy"),
            };

            return new ApiSuccessResult<GetReminder>(result);
        }

        public async Task<ApiResult<List<GetPack>>> GetPack(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<List<GetPack>>("Sản phẩm không tồn tại");
            }
            var query = from s in _context.Products
                        join d in _context.Packs on s.Id equals d.IdProduct
                        where s.Id == id
                        select new { d };

            var result = await query.Select(
                i => new GetPack()
                {
                    Id = i.d.Id,
                    Name = i.d.Name,
                    Value = i.d.Value,
                    Default = i.d.Default,
                }
                ).ToListAsync();

            return new ApiSuccessResult<List<GetPack>>(result);
        }

        public async Task<ApiResult<bool>> UpdatePack(UpdatePack bundle)
        {
            var pack = await _context.Packs.FindAsync(bundle.Id);
            if (pack == null)
            {
                return new ApiErrorResult<bool>("Đóng gói không tồn tại");
            }

            if (bundle.Default)
            {
                pack.Default = true;
                pack.Name = bundle.Name;
            }
            else
            {
                var count = await _context.Packs
               .Where(x => x.IdProduct == bundle.IdProduct && x.Id != bundle.Id)
               .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
               SystemConstants.Collate_AS) == bundle.Name.ToUpper().Trim());

                if (!count)
                {
                    pack.Default = false;
                    pack.Name = bundle.Name;
                    pack.Value = bundle.Value;
                }
                else
                {
                    return new ApiErrorResult<bool>("Tên đóng gói đã tồn tại");
                }
            }

            _context.Packs.Update(pack);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + PRODUCT_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}