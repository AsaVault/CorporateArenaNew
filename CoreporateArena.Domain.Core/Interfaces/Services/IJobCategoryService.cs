using CorporateArena.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain.Core.Interfaces.Services
{
    public interface IJobCategoryService
    {
        List<JobCategory> GetAllJobCategories();
        Task<List<JobCategory>> GetJobCategoryByPageAsync(int page, int pageSize);
        Task<bool> AddJobCategoryAsync(JobCategory jobCategory);
        JobCategory GetJobCategoryById(int id);
        Task<bool> UpdateJobCategoryAsync(JobCategory jobCategory);
        Task<bool> DeleteJobCategoryAsync(JobCategory jobCategory);
        Task SeedAsync();
    }
}
