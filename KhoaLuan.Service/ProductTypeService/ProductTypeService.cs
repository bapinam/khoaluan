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
using KhoaLuan.ViewModels.ProductType;
using KhoaLuan.Utilities.Constants;

namespace KhoaLuan.Service.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;

        public ProductTypeService(EnterpriseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<GetByIdListProductType>> GetById(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return new ApiErrorResult<GetByIdListProductType>("Loại nguyên vật liệu không tồn tại");
            }
            var query = await (from s in _context.ProductTypes
                               join g in _context.ProductTypeGroups on s.IdProductTypeGroup equals g.Id
                               where s.Id == id
                               select new GetByIdListProductType()
                               {
                                   Id = s.Id,
                                   Code = s.Code,
                                   Name = s.Name,
                                   IdGroupType = s.IdProductTypeGroup,
                                   GroupType = g.Name
                               }).FirstAsync();

            var result = new GetByIdListProductType()
            {
                Id = query.Id,
                Code = query.Code,
                Name = query.Name,
                IdGroupType = query.IdGroupType,
                GroupType = query.GroupType
            };

            return new ApiSuccessResult<GetByIdListProductType>(result);
        }

        public async Task<ApiResult<PagedResult<ProductTypeViewModel>>> GetUsersPaging(GetProductTypePagingRequest bundle)
        {
            var query = from s in _context.ProductTypes
                        join g in _context.ProductTypeGroups on s.IdProductTypeGroup equals g.Id

                        select new { s, g };

            if (bundle.GroupType > 0)
            {
                query = query.Where(x => x.g.Id == bundle.GroupType);
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
                .Select(i => new ProductTypeViewModel()
                {
                    Id = i.s.Id,
                    Code = i.s.Code,
                    Name = i.s.Name,
                    GroupType = i.g.Name
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductTypeViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProductTypeViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            if (id != null)
            {
                var count = await _context.ProductTypes
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
                var count = await _context.ProductTypes
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

        public async Task<ApiResult<bool>> Update(int id, UpdateProductType bundle)
        {
            var productType = await _context.ProductTypes.FindAsync(bundle.Id);
            if (productType == null)
            {
                return new ApiErrorResult<bool>("Loại nguyên vật liệu không tồn tại");
            }
            var list = _mapper.Map(bundle, productType);
            _context.ProductTypes.Update(list);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<int>> Create(CreateProductType bundle)
        {
            var productType = _mapper.Map<ProductType>(bundle);

            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            var stt = 1;
            Location:
            var location = code.Location + stt;

            var str = code.Name + location;

            var checkCode = await _context.ProductTypes.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                stt++;
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            productType.Code = str;

            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync(); // số bản ghi nếu return

            return new ApiSuccessResult<int>(productType.Id);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return new ApiErrorResult<bool>("Loại nguyên vật liệu không tồn tại");
            }
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetAllProductType>> GetAll()
        {
            var result = await _context.ProductTypes.OrderBy(i => i.Name)
                .Select(i => new GetAllProductType()
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToListAsync();

            return result;
        }
    }
}