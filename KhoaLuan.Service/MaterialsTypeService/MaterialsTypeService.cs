using KhoaLuan.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KhoaLuan.Data.Entities;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
using KhoaLuan.ViewModels.MaterialsType;
using KhoaLuan.Utilities.Constants;

namespace KhoaLuan.Service.MaterialsTypeService
{
    public class MaterialsTypeService : IMaterialsTypeService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;

        public MaterialsTypeService(EnterpriseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<GetByIdListMaterialsType>> GetById(int id)
        {
            var materialsType = await _context.MaterialsTypes.FindAsync(id);
            if (materialsType == null)
            {
                return new ApiErrorResult<GetByIdListMaterialsType>("Loại nguyên vật liệu không tồn tại");
            }
            var result = new GetByIdListMaterialsType()
            {
                Id = materialsType.Id,
                Code = materialsType.Code,
                Name = materialsType.Name,
                GroupType = materialsType.GroupType == GroupType.NguyenLieu ? "Nguyên Liệu" :
                              materialsType.GroupType == GroupType.NhienLieu ? "Nhiên Liệu" : "Vật Liệu"
            };

            return new ApiSuccessResult<GetByIdListMaterialsType>(result);
        }

        public async Task<ApiResult<PagedResult<MaterialsTypeViewModel>>>
            GetUsersPaging(GetMaterialsTypePagingRequest bundle)
        {
            IQueryable<MaterialsType> query = _context.MaterialsTypes;

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.Name.Contains(bundle.Keyword) || c.Code.Contains(bundle.Keyword));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.Id);
            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(i => new MaterialsTypeViewModel()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name,
                    GroupType = i.GroupType == GroupType.NguyenLieu ? "Nguyên Liệu" :
                                      i.GroupType == GroupType.NhienLieu ? "Nhiên Liệu" : "Vật Liệu"
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<MaterialsTypeViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<MaterialsTypeViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            if (id != null)
            {
                var count = await _context.MaterialsTypes
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(), SystemConstants.Collate_AS)
                    == name.ToUpper().Trim() && c.Id != id);
                if (count)
                {
                    return new ApiErrorResult<bool>("Tên loại nguyên vật liệu đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                var count = await _context.MaterialsTypes
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                    SystemConstants.Collate_AS) == name.ToUpper().Trim());

                if (count)
                {
                    return new ApiErrorResult<bool>("Tên loại nguyên vật liệu đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }

        public async Task<ApiResult<bool>> Update(int id, UpdateMaterialsType bundle)
        {
            var materialsType = await _context.MaterialsTypes.FindAsync(bundle.Id);
            if (materialsType == null)
            {
                return new ApiErrorResult<bool>("Loại nguyên vật liệu không tồn tại");
            }
            var list = _mapper.Map(bundle, materialsType);
            _context.MaterialsTypes.Update(list);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<int>> Create(CreateMaterialsType bundle)
        {
            var materialsType = _mapper.Map<MaterialsType>(bundle);
            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            var stt = 1;
            Location:
            var location = code.Location + stt;

            var str = code.Name + location;

            var checkCode = await _context.MaterialsTypes.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                stt++;
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            materialsType.Code = str;
            _context.MaterialsTypes.Add(materialsType);
            await _context.SaveChangesAsync(); // số bản ghi nếu return
            return new ApiSuccessResult<int>(materialsType.Id);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var materialsType = await _context.MaterialsTypes.FindAsync(id);
            if (materialsType == null)
            {
                return new ApiErrorResult<bool>("Loại nguyên vật liệu không tồn tại");
            }
            _context.MaterialsTypes.Remove(materialsType);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetAllMaterialsType>> GetAll()
        {
            var result = await _context.MaterialsTypes.OrderBy(i => i.Name)
                .Select(i => new GetAllMaterialsType()
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToListAsync();

            return result;
        }
    }
}