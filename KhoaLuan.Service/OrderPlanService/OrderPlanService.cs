using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.OrderPlan;
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

        public OrderPlanService(EnterpriseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}