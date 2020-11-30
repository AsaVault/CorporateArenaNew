using CorporateArena.DataAccess.Interfaces;
using CorporateArena.Domain.Core.Entities;
using CorporateArena.Domain.Core.Interfaces.Services;
using CorporateArena.UI.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain.Core.Implementation
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IRepository<JobCategory> _repo;

        public JobCategoryService(IRepository<JobCategory> repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddJobCategoryAsync(JobCategory jobCategory)
        {
           await _repo.AddAsync(jobCategory);
            var result = Task.Run(() => _repo.SaveAll());
            return await result;
        }

        public async Task<bool> DeleteJobCategoryAsync(JobCategory jobCategory)
        {
             _repo.Delete(jobCategory);
            var result = Task.Run(() => _repo.SaveAll());
            return await result;
        }

        public  List<JobCategory> GetAllJobCategories()
        {
            return   _repo.GetAll().ToList();
        }

        public async Task<List<JobCategory>> GetJobCategoryByPageAsync(int page, int pageSize)
        {
            var jobCategory = _repo.GetAll().OrderByDescending(x=>x.CreatedOn);
            var currentJobCategory = await PaginatedList<JobCategory>.CreateAsync(jobCategory, page, pageSize);
            return currentJobCategory.ToList();
        }

        public JobCategory GetJobCategoryById(int id)
        {
            return _repo.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateJobCategoryAsync(JobCategory jobCategory)
        {
            _repo.Update(jobCategory);
            var result = Task.Run(() => _repo.SaveAll());
            return await result;
        }
    }
}
