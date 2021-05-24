﻿using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin.Services
{
    public interface IProcessingDetailApiClient
    {
        Task<ApiResult<PagedResult<ProcessingPlanVm>>> GetProcessingCompleted(GetDistributingPagingRequest bundle);

        Task<ApiResult<ProcessingPlanVmCount>> GetDistributing(string key);

        Task<List<ProcessingDetailVm>> GetAllProcessDetailById(long id);

        Task<ApiResult<bool>> Create(CreateProcess bundle);

        Task<ApiResult<bool>> CancelProcess(long id);
    }
}