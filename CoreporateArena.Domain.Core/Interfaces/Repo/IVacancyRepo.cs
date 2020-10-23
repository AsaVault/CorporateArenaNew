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

        Task<List<Vacancy>> getByIndustryAsync(string industry);

        Task<List<Vacancy>> getByLocationAsync(string location);

        Task<List<Vacancy>> getByTitleAsync(string title);

        Task<List<Vacancy>> getByCompanyAsync(string company);


    }
}
