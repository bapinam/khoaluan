using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProductTypeGroup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProductTypeGroupService
{
    public class ProductTypeGroupService : IProductTypeGroupService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;

        public ProductTypeGroupService(EnterpriseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<GetByIdListProductTypeGroup>> GetById(int id)
        {
            var productTypeGroup = await _context.ProductTypeGroups.FindAsync(id);
            if (productTypeGroup == null)
            {
                return new ApiErrorResult<GetByIdListProductTypeGroup>("Nhóm loại  không tồn tại");
            }
            var result = new GetByIdListProductTypeGroup()
            {
                Id = productTypeGroup.Id,
                Code = productTypeGroup.Code,
                Name = productTypeGroup.Name
            };

            return new ApiSuccessResult<GetByIdListProductTypeGroup>(result);
        }

        public async Task<ApiResult<PagedResult<ProductTypeGroupViewModel>>> GetUsersPaging(GetProductTypeGroupPagingRequest bundle)
        {
            IQueryable<ProductTypeGroup> query = _context.ProductTypeGroups;

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.Name.Contains(bundle.Keyword) || c.Code.Contains(bundle.Keyword));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.Id);
            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(i => new ProductTypeGroupViewModel()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductTypeGroupViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProductTypeGroupViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            if (id != null)
            {
                var count = await _context.ProductTypeGroups
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(), SystemConstants.Collate_AS)
                    == name.ToUpper().Trim() && c.Id != id);
                if (count)
                {
                    return new ApiErrorResult<bool>("Tên nhóm loại đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                var count = await _context.ProductTypeGroups
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                    SystemConstants.Collate_AS) == name.ToUpper().Trim());

                if (count)
                {
                    return new ApiErrorResult<bool>("Tên nhóm loại đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }

        public async Task<ApiResult<bool>> Update(int id, UpdateProductTypeGroup bundle)
        {
            var productTypeGroup = await _context.ProductTypeGroups.FindAsync(bundle.Id);
            if (productTypeGroup == null)
            {
                return new ApiErrorResult<bool>("Nhóm loại không tồn tại");
            }
            var list = _mapper.Map(bundle, productTypeGroup);
            _context.ProductTypeGroups.Update(list);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<int>> Create(CreateProductTypeGroup bundle)
        {
            var productTypeGroup = _mapper.Map<ProductTypeGroup>(bundle);
            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var checkCode = await _context.ProductTypeGroups.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            productTypeGroup.Code = str;
            _context.ProductTypeGroups.Add(productTypeGroup);
            await _context.SaveChangesAsync(); // số bản ghi nếu return
            return new ApiSuccessResult<int>(productTypeGroup.Id);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var productTypeGroup = await _context.ProductTypeGroups.FindAsync(id);
            if (productTypeGroup == null)
            {
                return new ApiErrorResult<bool>("Nhóm loại không tồn tại");
            }
            _context.ProductTypeGroups.Remove(productTypeGroup);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetAllProductTypeGroup>> GetAll()
        {
            var result = await _context.ProductTypeGroups.OrderBy(i => i.Name)
                .Select(i => new GetAllProductTypeGroup()
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToListAsync();

            return result;
        }
    }
}