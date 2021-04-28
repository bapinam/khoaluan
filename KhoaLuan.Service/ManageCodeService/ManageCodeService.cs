﻿using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.CodeManage;
using KhoaLuan.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ManageCodeService
{
    public class ManageCodeService : IManageCodeService
    {
        private readonly EnterpriseDbContext _context;

        public ManageCodeService(EnterpriseDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(CreateCode bundle)
        {
            var code = _context.ManageCodes;

            var data = new ManageCode()
            {
                Name = bundle.Name,
                TypeCode = bundle.TypeCode
            };

            _context.ManageCodes.Add(data);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<List<GetAllCode>> GetAll(CodeType bundle)
        {
            var code = _context.ManageCodes
                .Where(x => x.TypeCode == bundle);

            var data = await code.Select(x => new GetAllCode()
            {
                Id = x.Id,
                Name = x.Name,
                Top = x.Top
            }).ToListAsync();

            return new List<GetAllCode>(data);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var iCode = await _context.ManageCodes.FindAsync(id);
            if (iCode == null)
            {
                return new ApiErrorResult<bool>();
            }

            _context.ManageCodes.Remove(iCode);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(UpdateCode bundle)
        {
            var code = await _context.ManageCodes.FindAsync(bundle.Id);
            if (code == null)
            {
                return new ApiErrorResult<bool>();
            }

            code.Name = bundle.Name;
            code.Top = bundle.Top;

            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> iName(string name, int? id)
        {
            if (id != null)
            {
                var count = await _context.ManageCodes
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(), SystemConstants.Collate_AS)
                    == name.ToUpper().Trim() && c.Id != id);
                if (count)
                {
                    return new ApiErrorResult<bool>("Tên mã đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
            else
            {
                var count = await _context.ManageCodes
                    .AnyAsync(c => EF.Functions.Collate(c.Name.ToUpper().Trim(),
                    SystemConstants.Collate_AS) == name.ToUpper().Trim());

                if (count)
                {
                    return new ApiErrorResult<bool>("Tên mã đã tồn tại");
                }
                else
                {
                    return new ApiSuccessResult<bool>();
                }
            }
        }
    }
}