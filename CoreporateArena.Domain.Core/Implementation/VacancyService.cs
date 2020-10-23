using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class VacancyService : IVacancyService
    {

        private readonly IUserService _uService;
        private readonly IVacancyRepo _vRepo;

        public VacancyService(IUserService uService, IVacancyRepo vRepo)
        {
            _uService = uService;
            _vRepo = vRepo;
        }


        public async Task<SaveResponse> DeleteVacancyAsync(int ID,int userID)
        {
                     

            await _vRepo.deleteAsync(ID);


            return new SaveResponse { status = true, Result = "Vacancy successfully deleted" };
        }

        public async Task<List<Vacancy>> GetAllVacanciesAsync()
        {
            var vacancies = await _vRepo.getAllAsync();
            return vacancies;
        }

        public async Task<Vacancy> GetVacancyByIDAsync(int ID)
        {
            // throw new NotImplementedException(
            var vacancy = await _vRepo.getAsync(ID);
            return vacancy;
        }

        public async Task<SaveResponse> SaveVacancyAsync(Vacancy data)
        {
            
            int VID = await _vRepo.insertAsync(data);
            return new SaveResponse { ID = VID, status = true, Result = "Vacancy successfully created" };
        }

        public async Task<SaveResponse> UpdateVacancyAsync(Vacancy data)
        {
            await _vRepo.updateAsync(data);
            return new SaveResponse { status = true, Result = "Vacancy successfully updated" };
        }

        public async Task<List<Vacancy>> GetVacancyByModeAsync(string mode)
        {
            var vacancies = await _vRepo.getByModeAsync(mode);
            return vacancies;

        }
        public async Task<List<Vacancy>> GetVacancyByIndustryAsync(string industry)
        {
            var vacancies = await _vRepo.getByIndustryAsync(industry);
            return vacancies;
        }
        public async Task<List<Vacancy>> GetVacancyByTitleAsync(string title)
        {
            var vacancies = await _vRepo.getByTitleAsync(title);
            return vacancies;
        }
        public async Task<List<Vacancy>> GetVacancyByLocationAsync(string location)
        {
            var vacancies = await _vRepo.getByLocationAsync(location);
            return vacancies;
        }

        

        

        

    }

}
