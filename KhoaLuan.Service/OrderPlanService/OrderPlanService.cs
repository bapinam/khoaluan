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
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public OrderPlanService(EnterpriseDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
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
            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var checkCode = await _context.ProductTypes.AnyAsync(x => x.Code == str);
            if (checkCode)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            oderPlan.Code = str;

            _context.OrderPlans.Update(oderPlan);
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
                Status = o.Status,
                CreatedDate = o.CreatedDate.ToString("dd-MM-yyyy"),
                ExpectedDate = o.ExpectedDate.ToString("dd-MM-yyyy"),
                Duration = o.ExpectedDate > DateTime.Now ? false : true,
                Note = o.Note,
                IdCreator = o.IdCreator,
                CodeCreator = o.Creator.Code,
                IdResponsible = o.IdResponsible,
                CodeResponsible = o.Responsible.Code,
                Count = count,
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
    }
}