﻿using KhoaLuan.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.RoleService
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}