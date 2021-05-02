using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.Service.Common;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Material;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KhoaLuan.Service.MaterialService
{
    public class MaterialService : IMaterialService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private const string PRODUCT_CONTENT_FOLDER_NAME = SystemConstants.ImageFolder;

        public MaterialService(EnterpriseDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<ApiResult<int>> Create(MaterialCreate bundle)
        {
            var pack = new List<Pack>();
            pack.Add(new Pack()
            {
                Name = bundle.NamePackDefault,
                Value = 1,
                PackType = PackType.Materials,
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
                        PackType = PackType.Materials,
                        Default = false
                    });
                    i++;
                }
            }

            var materials = new Material()
            {
                Code = bundle.Code,
                Name = bundle.Name,
                Description = bundle.Description,
                IdMaterialsType = bundle.IdMaterialType,
                Packs = pack
            };

            if (bundle.Min != null && bundle.Max != null)
            {
                materials.Reminder = true;
                materials.Min = bundle.Min;
                materials.Max = bundle.Max;
                materials.ReminderStartDate = (DateTime)bundle.ReminderStartDate;
                materials.ReminderEndDate = (DateTime)bundle.ReminderEndDate;
            }
            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var checkCode = await _context.Materials.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            materials.Code = str;
            _context.Materials.Add(materials);
            await _context.SaveChangesAsync(); // số bản ghi nếu return

            return new ApiSuccessResult<int>(materials.Id);
        }

        public async Task<ApiResult<GetIdPackMaterial>> CreatePack(PackMaterialCreate bundle)
        {
            var pack = new Pack()
            {
                Name = bundle.Name,
                Value = bundle.Value,
                Default = false,
                IdMaterials = bundle.IdMaterial
            };
            _context.Packs.Add(pack);
            await _context.SaveChangesAsync();

            var result = new GetIdPackMaterial()
            {
                Name = pack.Name,
                Value = pack.Value,
                Id = pack.Id
            };
            return new ApiSuccessResult<GetIdPackMaterial>(result);
        }

        public async Task<ApiResult<string>> UpdateImage(int id, ImageMaterial bundle)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return new ApiErrorResult<string>("Nguyên vật liệu không tồn tại");
            }
            // xóa ảnh củ
            if (materials.Image != null)
            {
                await _storageService.DeleteFileAsync(materials.Image);
            }

            // lưu lại ảnh mới
            materials.Image = await this.SaveFile(bundle.Image);
            _context.Materials.Update(materials);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<string>(materials.Image);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var materials = await _context.Materials.Include(x => x.Packs).FirstAsync(x => x.Id == id);
            if (materials == null)
            {
                return new ApiErrorResult<bool>("Nguyên vật liệu không tồn tại");
            }

            if (materials.Image != null)
            {
                await _storageService.DeleteFileAsync(materials.Image);
            }

            var reult = _context.Materials.Remove(materials);
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

        public async Task<ApiResult<int>> Update(int id, MaterialUpdate bundle)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return new ApiErrorResult<int>("Nguyên vật liệu không tồn tại");
            }

            materials.IdMaterialsType = bundle.IdMaterialType;
            materials.Name = bundle.Name;
            materials.Description = bundle.Description;

            _context.Materials.Update(materials);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(materials.Id);
        }

        public async Task<ApiResult<bool>> UpdateReminder(UpdateMaterialReminder bundle)
        {
            var materials = await _context.Materials.FindAsync(bundle.Id);
            if (materials == null)
            {
                return new ApiErrorResult<bool>("Nguyên vật liệu không tồn tại");
            }

            if (bundle.BoolReminder)
            {
                materials.Reminder = true;
                materials.Min = bundle.Min;
                materials.Max = bundle.Max;

                var str = bundle.DateReminder.Split(" - ");
                materials.ReminderStartDate = Convert.ToDateTime(str[0]);
                materials.ReminderEndDate = Convert.ToDateTime(str[1]);
            }
            else
            {
                materials.Reminder = false;
            }

            _context.Materials.Update(materials);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<MaterialVm>>> GetUsersPaging(GetMaterialPagingRequest bundle)
        {
            var query = from s in _context.Materials
                        join g in _context.MaterialsTypes on s.IdMaterialsType equals g.Id
                        join d in _context.Packs on s.Id equals d.IdMaterials
                        where d.Default == true

                        select new { s, g, d };

            if (bundle.MaterialType > 0)
            {
                query = query.Where(x => x.g.Id == bundle.MaterialType);
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
                .Select(i => new MaterialVm()
                {
                    Id = i.s.Id,
                    Code = i.s.Code,
                    Name = i.s.Name,
                    Image = i.s.Image,
                    Amount = i.s.Amount,
                    Reminder = i.s.Reminder,
                    NamePackDefault = i.d.Name,
                    NameMaterialType = i.g.Name,
                    AmountPercent = i.s.Max != null ? (int)(((double)i.s.Amount / (double)i.s.Max) * 100) : 0
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<MaterialVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<MaterialVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            if (id != null)
            {
                var count = await _context.Materials
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(), SystemConstants.Collate_AS)
                    == name.ToUpper().Trim() && c.Id != id);
                if (count)
                {
                    return new ApiErrorResult<bool>("Tên nguyên vật liệuđã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                var count = await _context.Materials
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                    SystemConstants.Collate_AS) == name.ToUpper().Trim());

                if (count)
                {
                    return new ApiErrorResult<bool>("Tên nguyên vật liệuđã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }

        public async Task<ApiResult<bool>> iNamePack(string name, int idLoai, bool status, long? id)
        {
            bool count;
            if (id == null)
            {
                if (status)
                {
                    count = await _context.Packs.Where(x => x.IdMaterials == idLoai)
                   .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                   SystemConstants.Collate_AS) == name.ToUpper().Trim());
                }
                else
                {
                    count = await _context.Packs
                  .Where(x => x.IdMaterials == idLoai && x.Default != true)
                  .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                  SystemConstants.Collate_AS) == name.ToUpper().Trim());
                }
            }
            else
            {
                count = await _context.Packs
               .Where(x => x.IdMaterials == idLoai && x.Id != id)
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

        public async Task<ApiResult<GetByIdListMaterial>> GetById(int id)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return new ApiErrorResult<GetByIdListMaterial>("Nguyên vật liệu không tồn tại");
            }
            var query = await (from s in _context.Materials
                               join g in _context.MaterialsTypes on s.IdMaterialsType equals g.Id
                               join d in _context.Packs on s.Id equals d.IdMaterials
                               where d.Default == true && s.Id == id
                               select new { s, g, d }).FirstAsync();

            var result = new GetByIdListMaterial()
            {
                Id = query.s.Id,
                Code = query.s.Code,
                Name = query.s.Name,
                Image = query.s.Image,
                Amount = query.s.Amount,
                Reminder = query.s.Reminder,
                NamePackDefault = query.d.Name,
                NameMaterialType = query.g.Name,
                AmountPercent = query.s.Max != null ? (int)(query.s.Amount / query.s.Max * 100) : 0
            };

            return new ApiSuccessResult<GetByIdListMaterial>(result);
        }

        public async Task<ApiResult<GetByIdMaterial>> GetByIdMaterial(int id)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return new ApiErrorResult<GetByIdMaterial>("Nguyên vật liệu không tồn tại");
            }

            var query = await (from s in _context.Materials
                               join g in _context.MaterialsTypes on s.IdMaterialsType equals g.Id
                               join d in _context.Packs on s.Id equals d.IdMaterials
                               where s.Id == id
                               select new { s, g, d }).FirstAsync();

            var result = new GetByIdMaterial()
            {
                Id = materials.Id,
                Code = materials.Code,
                Name = materials.Name,
                Image = materials.Image,
                IdMaterialType = materials.IdMaterialsType,
                NameMaterialType = query.g.Name,
                Description = materials.Description,
                Amount = materials.Amount,
                Reminder = materials.Reminder
            };

            result.NamePackDefault = query.s.Packs.Where(x => x.Default == true).Select(x => x.Name).First();

            var pack = from s in _context.Materials
                       join d in _context.Packs on s.Id equals d.IdMaterials
                       where s.Id == id && d.Default != true
                       select new { s, d };

            result.Pack = pack.Select(
                i => new GetMaterialPack()
                {
                    Name = i.d.Name,
                    Value = i.d.Value,
                    Default = i.d.Default,
                    Change = (long)(result.Amount / i.d.Value)
                }
                ).ToList();
            return new ApiSuccessResult<GetByIdMaterial>(result);
        }

        public async Task<ApiResult<UpdateMaterialReturn>> GetByUpdateMaterial(int id)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return new ApiErrorResult<UpdateMaterialReturn>("Nguyên vật liệu không tồn tại");
            }

            var query = await (from s in _context.Materials
                               join g in _context.MaterialsTypes on s.IdMaterialsType equals g.Id
                               where s.Id == id
                               select new { g.Name }).FirstAsync();

            var result = new UpdateMaterialReturn()
            {
                Id = materials.Id,
                Code = materials.Code,
                Name = materials.Name,
                Image = materials.Image,
                NameMaterialType = query.Name,
                Description = materials.Description
            };

            return new ApiSuccessResult<UpdateMaterialReturn>(result);
        }

        public async Task<ApiResult<GetMaterialReminder>> GetReminder(int id)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return new ApiErrorResult<GetMaterialReminder>("Nguyên vật liệu không tồn tại");
            }

            var result = new GetMaterialReminder()
            {
                Reminder = materials.Reminder,
                Min = materials.Min,
                Max = materials.Max,
                ReminderStartDate = materials.ReminderStartDate.ToString("MM/dd/yyyy"),
                ReminderEndDate = materials.ReminderEndDate.ToString("MM/dd/yyyy"),
            };

            return new ApiSuccessResult<GetMaterialReminder>(result);
        }

        public async Task<ApiResult<List<GetMaterialPack>>> GetPack(int id)
        {
            var materials = await _context.Materials.FindAsync(id);
            if (materials == null)
            {
                return new ApiErrorResult<List<GetMaterialPack>>("Nguyên vật liệu không tồn tại");
            }
            var query = from s in _context.Materials
                        join d in _context.Packs on s.Id equals d.IdMaterials
                        where s.Id == id
                        select new { d };

            var result = await query.Select(
                i => new GetMaterialPack()
                {
                    Id = i.d.Id,
                    Name = i.d.Name,
                    Value = i.d.Value,
                    Default = i.d.Default,
                }
                ).ToListAsync();

            return new ApiSuccessResult<List<GetMaterialPack>>(result);
        }

        public async Task<ApiResult<bool>> UpdatePack(UpdateMaterialPack bundle)
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
               .Where(x => x.IdMaterials == bundle.IdMaterial && x.Id != bundle.Id)
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