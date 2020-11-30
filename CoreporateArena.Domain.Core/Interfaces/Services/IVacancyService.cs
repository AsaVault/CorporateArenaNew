using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IVacancyService
    {
        Task<SaveResponse> SaveVacancyAsync(Vacancy data);

        Task<Vacancy> GetVacancyByIDAsync(int ID);
        
        Task<List<Vacancy>> GetAllVacanciesAsync();

        Task<List<Vacancy>> GetVacancyByModeAsync(string mode);

        Task<List<Vacancy>> GetVacancyByJobCategoryAsync(string jobCategory);

        Task<List<Vacancy>> GetVacancyByTitleAsync(string title);

        Task<List<Vacancy>> GetVacancyByLocationAsync(string location);
        Task<List<Vacancy>> GetVacancyByJobCategoryIdAsync(int id);
        Task<List<Vacancy>> GetVacancyByCompanyIdAsync(int id);
        Task<List<Vacancy>> GetVacancyByJobTypeAsync(int id);

        Task<SaveResponse> UpdateVacancyAsync(Vacancy data);
        
        Task<SaveResponse> DeleteVacancyAsync(int ID, int userID);
    }
}
