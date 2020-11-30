using CorporateArena.DataAccess.Entities;
using CorporateArena.DataAccess.Interfaces;
using CorporateArena.Domain.Core.Interfaces.Services;
using CorporateArena.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain.Core.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _repo;

        public CompanyService(IRepository<Company> repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddCompanyAsync(Company company)
        {
           await _repo.AddAsync(company);
            var result = Task.Run(() => _repo.SaveAll());
            return await result;
        }

        public async Task<bool> DeleteCompanyAsync(Company company)
        {
             _repo.Delete(company);
            var result = Task.Run(() => _repo.SaveAll());
            return await result;
        }

        public List<Company> GetAllCompanies()
        {
            return _repo.GetAll().ToList();
        }

        public async Task<List<Company>> GetCompanyByPageAsync(int page, int pageSize)
        {
            var company = _repo.GetAll().OrderByDescending(x => x.CreatedOn);
            var currentCompany = await PaginatedList<Company>.CreateAsync(company, page, pageSize);
            return currentCompany.ToList();
        }

        public Company GetCompanyById(int id)
        {
           return  _repo.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCompanyAsync(Company company)
        {
            _repo.Update(company);
            var result = Task.Run(() => _repo.SaveAll());
            return result;
        }
    }
}
