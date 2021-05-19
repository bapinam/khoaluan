using KhoaLuan.ViewModels.Common;
using KhoaLuan.ViewModels.ProcessPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.ProcessPlanService
{
    public interface IProcessPlanService
    {
        Task<List<GetAllProductGroup>> GetAllProductGroup();

        Task<List<GetAllProductType>> GetAllProductType(int id);

        Task<List<GetAllProductRecipes>> GetAllProductRecipes(int id, string key);

        Task<List<GetEmployee>> GetEmployee(string key);

        Task<List<GetListPacksById>> GetListPacksById(int id);

        Task<List<GetListPacksProduct>> GetListPacksProduct(int id);

        Task<ApiResult<bool>> Create(CreatePlan bundle);

        Task<List<GetByProcessPlanCensorship>> GetByProcessPlanCensorship();

        Task<ApiResult<GetProcessPlanById>> GetProcessPlanById(long id);

        Task<ApiResult<long>> Update(UpdatePlan bundle);

        Task<ApiResult<bool>> Delete(long id);

        Task<ApiResult<PagedResult<ProcessPlanVm>>> GetProcessPlanPaging(GetProcessPlanPagingRequest bundle);

        Task<ApiResult<GetProcessPlanByIdRecipes>> GetProcessPlanByIdRecipes(long id);

        Task<List<GetByProcessPlanCensorship>> GetByProcessPlanApproved(string key);

        Task<List<GetMaterialsByRecipes>> GetMaterialsByRecipes(int idRecipe);

        Task<ApiResult<bool>> UpdateProcessPlanCensorship(UpdateCensorship bundle);
    }
}