﻿using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessingDetail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProcessingDetailService
{
    public interface IProcessingDetailService
    {
        Task<ApiResult<PagedResult<ProcessingPlanVm>>> GetProcessingCompleted(GetDistributingPagingRequest bundle);

        Task<ApiResult<ProcessingPlanVmCount>> GetDistributing(string key);

        Task<List<ProcessingDetailVm>> GetAllProcessDetailById(long id);

        Task<ApiResult<bool>> Create(CreateProcess bundle);

        Task<ApiResult<bool>> CancelProcess(long id);
    }
}