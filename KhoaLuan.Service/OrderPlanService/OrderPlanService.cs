using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.OrderPlan;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.OrderPlanService
{
    public class OrderPlanService : IOrderPlanService
    {
        private readonly EnterpriseDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderPlanService(EnterpriseDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApiResult<PagedResult<OrderPlanVm>>> GetOrderPlanPaging(GetOrderPlanPagingRequest bundle)
        {
            IQueryable<OrderPlan> query = _context.OrderPlans;

            if (!string.IsNullOrEmpty(bundle.Status))
            {
                switch (bundle.Status)
                {
                    case "true":
                        query = query.Where(c => c.Status == StatusOrderPlan.Accomplished);
                        break;

                    case "false":
                        query = query.Where(c => c.Status == StatusOrderPlan.Cancel);
                        break;
                }
            }

            query = query.Where(c => c.Status != StatusOrderPlan.Unfinished);

            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                query = query.Where(c => c.Name.Contains(bundle.Keyword) || c.Code.Contains(bundle.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(c => c.Id);

            query = query.Include(x => x.Creator).Include(l => l.Responsible);

            var data = await query.Skip((bundle.PageIndex - 1) * bundle.PageSize)
                .Take(bundle.PageSize)
                .Select(i => new OrderPlanVm()
                {
                    Id = i.Id,
                    Code = i.Code,
                    Name = i.Name,
                    Status = i.Status == StatusOrderPlan.Accomplished ? "Đã hoàn thành" :
                         i.Status == StatusOrderPlan.Cancel ? "Đã hủy" : "Đang đặt hàng",
                    CreatedDate = i.CreatedDate.ToString("dd-MM-yyyy"),
                    CodeCreator = i.Creator.Code,
                    CodeResponsible = i.Responsible.Code
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<OrderPlanVm>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<OrderPlanVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Create(CreateOrderPlan bundle)
        {
            var order = _context.OrderPlans.Include(x => x.OrderDetails);

            var orderDetails = new List<OrderDetail>();

            if (bundle.Pack.Length > 0)
            {
                var i = 0;
                foreach (var item in bundle.Pack)
                {
                    orderDetails.Add(new OrderDetail()
                    {
                        Amount = bundle.Amount[i],
                        IdMaterials = bundle.IdMaterials[i],
                        Unit = item
                    });

                    i++;
                }
            }

            var oderPlan = new OrderPlan()
            {
                Name = bundle.Name,
                ExpectedDate = bundle.ExpectedDate,
                CreatedDate = DateTime.Now,
                Note = bundle.Note,
                IdResponsible = bundle.IdResponsible,
                OrderDetails = orderDetails
            };
            var user = await _userManager.FindByNameAsync(bundle.NameCreator);
            oderPlan.IdCreator = user.Id;

            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.Code);
            var stt = 1;
            Location:
            var location = code.Location + stt;

            var str = code.Name + location;

            var checkCode = await _context.OrderPlans.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                stt++;
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            oderPlan.Code = str;

            _context.OrderPlans.Add(oderPlan);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetByOrderPlan>> GetByOrderPlanCensorship()
        {
            var order = _context.OrderPlans.Include(x => x.OrderDetails)
                .ThenInclude(m => m.Material).Where(o => o.Censorship == false);

            order = order.Include(t => t.Responsible);
            var re = order.Include(g => g.Creator).OrderByDescending(x => x.Id);

            var count = await order.CountAsync();
            var reuslt = await re.Select(o => new GetByOrderPlan()
            {
                Id = o.Id,
                Code = o.Code,
                Name = o.Name,
                Order = o.Order,
                Censorship = o.Censorship,
                CreatedDate = o.CreatedDate.ToString("dd-MM-yyyy"),
                ExpectedDate = o.ExpectedDate.ToString("dd-MM-yyyy"),
                Duration = o.ExpectedDate.Date >= DateTime.Now.Date ? true : false,
                Note = o.Note == null ? "" : o.Note,
                IdCreator = o.IdCreator,
                CodeCreator = o.Creator.Code,
                IdResponsible = o.IdResponsible,
                CodeResponsible = o.Responsible.Code,
                NameResponsible = o.Responsible.UserName,
                Count = count,
                Status = o.Status == StatusOrderPlan.Accomplished ? "Đã hoàn thành" :
                         o.Status == StatusOrderPlan.Cancel ? "Đã hủy" : "Đang đặt hàng",
                ListOrderDetails = o.OrderDetails.Select(
                  i => new ListOrderDetails()
                  {
                      IdOrderDetail = i.Id,
                      CodeMaterials = i.Material.Code,
                      Amount = i.Amount,
                      Unit = i.Unit,
                      CodeSuppliers = i.IdSupplier == null ? "" : i.Supplier.Code,
                      Price = (decimal)(i.Price == null ? 0 : i.Price),
                      NameMaterials = i.Material.Name
                  }).ToList()
            }).ToListAsync();

            return new List<GetByOrderPlan>(reuslt);
        }

        // đã duyệt
        public async Task<List<GetByOrderPlan>> GetByOrderPlanApproved(string key)
        {
            var order = _context.OrderPlans;
            order.Include(x => x.OrderDetails)
           .ThenInclude(m => m.Material);
            var cr = order.Include(g => g.Creator);

            var re = cr.Include(t => t.Responsible).Where(t => t.Responsible.UserName == key);

            re = re.OrderByDescending(x => x.Id);
            re = re.Where(o => (o.Censorship == true && o.Status == StatusOrderPlan.Unfinished));
            var count = await re.CountAsync();

            var reuslt = await re.Select(o => new GetByOrderPlan()
            {
                Id = o.Id,
                Code = o.Code,
                Name = o.Name,
                Order = o.Order,
                Censorship = o.Censorship,
                CreatedDate = o.CreatedDate.ToString("dd-MM-yyyy"),
                ExpectedDate = o.ExpectedDate.ToString("dd-MM-yyyy"),
                Duration = o.ExpectedDate.Date >= DateTime.Now.Date ? true : false,
                Note = o.Note == null ? "" : o.Note,
                IdCreator = o.IdCreator,
                CodeCreator = o.Creator.Code,
                IdResponsible = o.IdResponsible,
                CodeResponsible = o.Responsible.Code,
                Count = count,
                Status = o.Status == StatusOrderPlan.Accomplished ? "Đã hoàn thành" :
                         o.Status == StatusOrderPlan.Cancel ? "Đã hủy" : "Đang đặt hàng",
                ListOrderDetails = o.OrderDetails.Select(
                  i => new ListOrderDetails()
                  {
                      IdOrderDetail = i.Id,
                      CodeMaterials = i.Material.Code,
                      Amount = i.Amount,
                      Unit = i.Unit,
                      CodeSuppliers = i.IdSupplier == null ? "" : i.Supplier.Code,
                      Price = (decimal)(i.Price == null ? 0 : i.Price),
                      NameMaterials = i.Material.Name
                  }).ToList()
            }).ToListAsync();

            return new List<GetByOrderPlan>(reuslt);
        }

        public async Task<List<GetEmployee>> GetEmployee(string key)
        {
            var user = _userManager.Users
                .Where(x => (x.FirstName.Contains(key) || x.LastName.Contains(key) || x.Code.Contains(key)
                || x.Card.Contains(key)) && x.JobStatus == JobStatus.Working);

            var result = await user.Select(x => new GetEmployee()
            {
                Id = x.Id,
                Code = x.Code,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Card = x.Card
            }).ToListAsync();

            return new List<GetEmployee>(result);
        }

        public async Task<List<GetMaterialsPlan>> GetMaterialsSearch(int id, string key)
        {
            var materials = _context.Materials;

            var result = await materials
                .Where(x => x.IdMaterialsType == id &&
                (x.Name.Contains(key) || x.Code.Contains(key)))
                .Select(
                x => new GetMaterialsPlan()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Amount = x.Amount,
                    Image = x.Image,
                    Max = x.Max == null ? 0 : x.Max
                }).ToListAsync();

            return new List<GetMaterialsPlan>(result);
        }

        public async Task<List<GetMaterialsTypePlan>> GetMaterialsType(GroupType group)
        {
            var materialsType = _context.MaterialsTypes;

            var result = await materialsType
                .Where(x => x.GroupType == group)
                .Select(
                x => new GetMaterialsTypePlan()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return new List<GetMaterialsTypePlan>(result);
        }

        public async Task<List<GetListSuppliersPlan>> GetListSuppliersPlan(string key)
        {
            var suppliers = _context.Suppliers;

            var result = await suppliers
             .Where(x => x.Name.Contains(key) || x.Code.Contains(key))
             .Select(x => new GetListSuppliersPlan()
             {
                 Id = x.Id,
                 Code = x.Code,
                 Name = x.Name,
                 Address = x.Address
             }).ToListAsync();

            return new List<GetListSuppliersPlan>(result);
        }

        public async Task<ApiResult<bool>> UpdateOrderPlanCensorship(UpdateOrderPlanCensorship bundle)
        {
            var order = await _context.OrderPlans.FindAsync(bundle.Id);
            if (order == null)
            {
                return new ApiErrorResult<bool>("Kế hoạch không tồn tại");
            }

            order.Censorship = true;

            var orderDetail = new List<OrderDetail>();
            if (bundle.IdOrderDetail.Length > 0)
            {
                var i = 0;
                foreach (var item in bundle.IdOrderDetail)
                {
                    var od = await _context.OrderDetails.FindAsync(item);
                    if (bundle.IdSupplier[i] != 0)
                    {
                        od.IdSupplier = bundle.IdSupplier[i];
                    }
                    od.Price = Decimal.Parse(bundle.Price[i]);
                    orderDetail.Add(od);
                    i++;
                }
            }
            order.OrderDetails = orderDetail;
            var authority = await _userManager.FindByNameAsync(bundle.Authority);

            order.IdAuthority = authority.Id;

            _context.OrderPlans.Update(order);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var order = await _context.OrderPlans
                .Include(x => x.OrderDetails)
                .FirstAsync(x => x.Id == id);
            if (order == null)
            {
                return new ApiErrorResult<bool>("Kế hoạch không tồn tại");
            }
            _context.OrderPlans.Remove(order);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<GetOrderPlan>> GetOrderPlan(long id)
        {
            var orderPlan = await _context.OrderPlans
                .Include(x => x.Responsible)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = new GetOrderPlan()
            {
                Id = orderPlan.Id,
                Code = orderPlan.Code,
                DateMan = orderPlan.ExpectedDate.ToString("yyyy-MM-dd"),
                ExpectedDate = orderPlan.ExpectedDate.ToString("dd-MM-yyyy"),
                Duration = orderPlan.ExpectedDate.Date >= DateTime.Now.Date ? true : false,
                Name = orderPlan.Name,
                Note = orderPlan.Note,
                NameResponsible = orderPlan.Responsible.UserName,
                IdResponsible = orderPlan.IdResponsible,
                CodeResponsible = orderPlan.Responsible.Code
            };

            return new ApiSuccessResult<GetOrderPlan>(result);
        }

        public async Task<ApiResult<long>> Update(UpdateOrderPlan bundle)
        {
            var order = await _context.OrderPlans.FindAsync(bundle.Id);

            order.Name = bundle.Name;
            order.Note = bundle.Note;
            order.IdResponsible = bundle.IdResponsible;
            order.ExpectedDate = bundle.ExpectedDate;

            _context.OrderPlans.Update(order);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<long>(order.Id);
        }

        public async Task<ApiResult<GetByOrderPlan>> GetByIdOrderPlan(long id)
        {
            var order = _context.OrderPlans
                .Include(x => x.OrderDetails).ThenInclude(x => x.Material)
                .Where(x => x.Id == id);

            var re = order.Include(r => r.Responsible);
            var au = re.Include(a => a.Authority);
            var cr = au.Include(c => c.Creator);
            if (order == null)
            {
                return new ApiErrorResult<GetByOrderPlan>("Kế hoạch không tồn tại");
            }

            var result = await cr.Select(x => new GetByOrderPlan()
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                CodeAuthority = x.Authority.Code,
                CodeCreator = x.Creator.Code,
                CodeResponsible = x.Responsible.Code,
                CreatedDate = x.CreatedDate.ToString("dd-MM-yyyy"),
                ExpectedDate = x.ExpectedDate.ToString("dd-MM-yyyy"),
                Note = x.Note,
                Status = x.Status == StatusOrderPlan.Accomplished ? "Đã hoàn thành" :
                         x.Status == StatusOrderPlan.Cancel ? "Đã hủy" : "Đang đặt hàng",
                ListOrderDetails = x.OrderDetails.Select(
                  i => new ListOrderDetails()
                  {
                      IdOrderDetail = i.Id,
                      CodeMaterials = i.Material.Code,
                      Amount = i.Amount,
                      Unit = i.Unit,
                      CodeSuppliers = i.IdSupplier == null ? "" : i.Supplier.Code,
                      Price = (decimal)(i.Price == null ? 0 : i.Price),
                      NameMaterials = i.Material.Name
                  }).ToList()
            }).FirstOrDefaultAsync();

            return new ApiSuccessResult<GetByOrderPlan>(result);
        }

        public async Task<List<GetListPacksById>> GetListPacksById(int id)
        {
            var pack = await _context.Materials.Include(x => x.Packs)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            var result = pack.Packs.Select(
                x => new GetListPacksById()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Default = x.Default,
                    Value = x.Value
                }).ToList();
            return new List<GetListPacksById>(result);
        }
    }
}