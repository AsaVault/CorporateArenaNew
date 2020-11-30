using CorporateArena.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Task<List<Company>> GetCompanyByPageAsync(int page, int pageSize);
        Task<bool> AddCompanyAsync(Company company);
        Company GetCompanyById(int id);
        Task<bool> UpdateCompanyAsync(Company company);
        Task<bool> DeleteCompanyAsync(Company company);
        Task SeedAsync();
    }
}
