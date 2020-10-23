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

        Task<List<Vacancy>> GetVacancyByIndustryAsync(string industry);

        Task<List<Vacancy>> GetVacancyByTitleAsync(string title);

        Task<List<Vacancy>> GetVacancyByLocationAsync(string location);

        Task<SaveResponse> UpdateVacancyAsync(Vacancy data);
        
        Task<SaveResponse> DeleteVacancyAsync(int ID, int userID);
    }
}
