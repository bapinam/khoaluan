using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.Supplier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;

        public SupplierService(EnterpriseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<int>> Create(SupplierCreate bundle)
        {
            var supplier = _mapper.Map<Supplier>(bundle);

            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            var stt = 1;
            Location:
            var location = code.Location + stt;

            var str = code.Name + location;

            var checkCode = await _context.Suppliers.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                stt++;
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            supplier.Code = str;
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync(); // số bản ghi nếu return

            return new ApiSuccessResult<int>(supplier.Id);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return new ApiErrorResult<bool>("Nhà cung cấp không tồn tại");
            }

            var reult = _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<GetByIdListSupplier>> GetById(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return new ApiErrorResult<GetByIdListSupplier>("Người dùng không tồn tại");
            }
            var supplierVm = _mapper.Map<GetByIdListSupplier>(supplier);

            return new ApiSuccessResult<GetByIdListSupplier>(supplierVm);
        }

        public async Task<ApiResult<PagedResult<SupplierVm>>> GetUsersPaging(GetSupplierPagingRequest bundle)
        {
            IQueryable<Supplier> query = _context.Suppliers;

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.Name.Contains(bundle.Keyword) || c.Code.Contains(bundle.Keyword));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.Id);
            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(x => new SupplierVm()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Tax = x.Tax,
                    Name = x.Name,
                    Phone = x.Phone,
                    Email = x.Email,
                    Address = x.Address
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<SupplierVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<SupplierVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Update(int id, SupplierUpdate bundle)
        {
            var user = await _context.Suppliers.FindAsync(id);
            if (user == null)
            {
                return new ApiErrorResult<bool>("Nhà cung cấp không tồn tại");
            }
            var list = _mapper.Map(bundle, user);

            _context.Suppliers.Update(list);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> iEmail(string email, int? id)
        {
            if (id != null)
            {
                if (await _context.Suppliers.AnyAsync(x => x.Email == email && x.Id != id))
                {
                    return new ApiErrorResult<bool>("Email đã tồn tại nhà cung cấp");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                if (await _context.Suppliers.AnyAsync(x => x.Email == email))
                {
                    return new ApiErrorResult<bool>("Email đã tồn tại nhà cung cấp");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }

        public async Task<ApiResult<bool>> iTax(string tax, int? id)
        {
            if (id != null)
            {
                if (await _context.Suppliers.AnyAsync(x => x.Tax == tax && x.Id != id))
                {
                    return new ApiErrorResult<bool>("Mã số thuế đã tồn tại nhà cung cấp");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                if (await _context.Suppliers.AnyAsync(x => x.Tax == tax))
                {
                    return new ApiErrorResult<bool>("Mã số thuế đã tồn tại nhà cung cấp");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }
    }
}