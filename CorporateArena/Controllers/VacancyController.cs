using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using CorporateArena.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _service;

        public VacancyController(IVacancyService service)
        {
            _service = service;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Authorize]
        ///[AuthorizePermission(Permissions = Permission.CreateVacancy)]
        [HttpPost("SaveVacancy")]
        public async Task<IActionResult> SaveVacancy(Vacancy data)
        {
            var result = await _service.SaveVacancyAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllVacancies")]
        public async Task<IActionResult> GetAllVacancies(string title, string location)
        {
            var result = await _service.GetAllVacanciesAsync();
            var resultQuerable = result.AsQueryable();
            if (!string.IsNullOrWhiteSpace(title))
            {
                resultQuerable = resultQuerable.Where(x => x.JobTitle.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                resultQuerable = resultQuerable.Where(x => x.Location.ToLower().Contains(location.ToLower()));
            }

            return Ok(resultQuerable.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancy/{ID}")]
        public async Task<IActionResult> GetVacancy(int ID)
        {
            var result = await _service.GetVacancyByIDAsync(ID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancyByMode/{mode}")]
        public async Task<IActionResult> GetVacancyByMode(string mode)
        {
            var result = await _service.GetVacancyByModeAsync(mode);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancyByTitle/{title}")]
        public async Task<IActionResult> GetVacancyByTitle(string title)
        {
            var result = await _service.GetVacancyByTitleAsync(title);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancyByLocation/{location}")]
        public async Task<IActionResult> GetVacancyByLocation(string location)
        {
            var result = await _service.GetVacancyByLocationAsync(location);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobCategory"></param>
        /// <returns></returns>

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancyByIndustry/{jobCategory}")]
        public async Task<IActionResult> GetVacancyByJobCategory(string jobCategory)
        {
            var result = await _service.GetVacancyByJobCategoryAsync(jobCategory);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancyByJobCategoryId/{id}")]
        public async Task<IActionResult> GetVacancyByJobCategoryId(int id)
        {
            var result = await _service.GetVacancyByJobCategoryIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancyByCompanyId/{id}")]
        public async Task<IActionResult> GetVacancyByCompanyId(int id)
        {
            var result = await _service.GetVacancyByCompanyIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadVacancy)]
        [HttpGet("GetVacancyByJobType/{id}")]
        public async Task<IActionResult> GetVacancyByJobType(int id)
        {
            var result = await _service.GetVacancyByJobTypeAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="VacancyID"></param>
        /// <returns></returns>

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.DeleteVacancy)]
        [HttpDelete("DeleteVacancy/{UserID}/{VacancyID}")]
        public async Task<IActionResult> DeleteVacancy(int UserID, int VacancyID)
        {
            var result = await _service.DeleteVacancyAsync(VacancyID, UserID);
            return Ok(result);
        }
    }
}
