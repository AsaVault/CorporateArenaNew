using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IVacancyRepo
    {
       
        
        Task deleteAsync(int ID);
        
        Task<List<Vacancy>> getAllAsync();
        
        Task<int> insertAsync(Vacancy data);
        
        Task updateAsync(Vacancy data);
        Task<Vacancy> getAsync(int ID);
        Task<List<Vacancy>> getByModeAsync(string mode);

        Task<List<Vacancy>> getByJobCategoryAsync(string jobCategory);

        Task<List<Vacancy>> getByLocationAsync(string location);

        Task<List<Vacancy>> getByTitleAsync(string title);
        Task<List<Vacancy>> getByJobCategoryIdAsync(int id);
        Task<List<Vacancy>> getByCompanyIdAsync(int id);
        Task<List<Vacancy>> getByJobTypeAsync(int id);
        Task<List<Vacancy>> getByCompanyAsync(string company);


    }
}
