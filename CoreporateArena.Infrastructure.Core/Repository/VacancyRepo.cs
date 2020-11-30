using CorporateArena.DataAccess.Entities;
using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class VacancyRepo : IVacancyRepo
    {

        private readonly TContext _context;
        public VacancyRepo (TContext context)
        {
            _context = context;
        }
        

        public async Task deleteAsync(int ID)
        {
            try
            {
                var vacancy=await _context.Vacancies.FindAsync(ID);
                _context.Vacancies.Remove(vacancy);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getAllAsync()
        {
            try
            {
                var vacancies = await _context.Vacancies.Include(x=>x.Company).Include(x => x.JobCategory).OrderByDescending(x=>x.CreatedOn).ToListAsync();
                return vacancies;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Vacancy> getAsync(int ID)
        {
           try
            {
                var vacancy = await _context.Vacancies.FindAsync(ID);
                return vacancy;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getByCompanyAsync(string company)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.Company.Name == company).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getByJobCategoryAsync(string jobCategory)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.JobCategory.Name == jobCategory).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getByLocationAsync(string location)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.Location == location).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getByModeAsync(string mode)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.Mode == mode).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getByTitleAsync(string title)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.JobTitle == title).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getByJobCategoryIdAsync(int id)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.JobCategoryId == id).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;      
            }
        }

        public async Task<List<Vacancy>> getByCompanyIdAsync(int id)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.CompanyId == id).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vacancy>> getByJobTypeAsync(int id)
        {
            try
            {
                var vacancies = await _context.Vacancies.Where(x => x.JobType.GetHashCode() == id).ToListAsync();
                return vacancies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(Vacancy data)
        {
            try
            {
                var vacancy = new Vacancy
                {
                    CreatedOn = DateTime.Now,
                    JobDescription = data.JobDescription,
                    JobTitle = data.JobTitle,
                    JobExperiences = data.JobExperiences,
                    JobResponsibilities = data.JobResponsibilities,
                    JobSkills = data.JobSkills,
                    JobSummary = data.JobSummary,
                    JobType = data.JobType,
                    CompanyId = data.CompanyId,
                    Email = data.Email,
                    Location = data.Location,
                    Url = data.Url,
                    RequiredKnowledge = data.RequiredKnowledge,
                    Salary = data.Salary,
                    KeyPerformance = data.KeyPerformance,
                    UserCreated = data.UserCreated,
                    JobCategoryId=data.JobCategoryId,
                    Mode=data.Mode
                };
                await _context.Vacancies.AddAsync(vacancy);
                await _context.SaveChangesAsync();
                return vacancy.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task updateAsync(Vacancy data)
        {
            try
            {
                var vacancy=await _context.Vacancies.FindAsync(data.ID);
                if (data.JobDescription != null) vacancy.JobDescription = data.JobDescription;
                if (data.JobTitle != null) vacancy.JobTitle = data.JobTitle;
                if (data.Location != null) vacancy.Location = data.Location;
                if (data.Url != null) vacancy.Url = data.Url;
                if (data.Email != null) vacancy.Email = data.Email;
                if (data.Company != null) vacancy.Company = data.Company;
                vacancy.UpdatedOn = DateTime.Now;

                _context.Vacancies.Update(vacancy);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
