using CorporateArena.DataAccess.Entities;
using CorporateArena.Domain.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        // GET: api/GetByPageAsync
        [HttpGet("{page}/{pageSize}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByPageAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                var companies = await _service.GetCompanyByPageAsync(page, pageSize);
                return StatusCode((int)HttpStatusCode.OK, companies);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var companies = _service.GetAllCompanies();
                return StatusCode((int)HttpStatusCode.OK, companies);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        // Get: api/GetById
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var company = _service.GetCompanyById(id);
                return StatusCode((int)HttpStatusCode.OK, company);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }

        }
        // POST: api/CreateAsync
        [HttpPost("")]
        public async Task<IActionResult> CreateAsync([FromBody] Company model)
        {
            try
            {
                if (model.ValidationErrors().Any())
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", model.ValidationErrors()));
                }

                var newCompany = new Company
                {
                    Id = model.Id,
                    Name = model.Name,
                    About = model.About,
                    LogoUrl = model.LogoUrl,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsDisplayed = true,
                    IsDeleted = false
                };

                var result = await _service.AddCompanyAsync(newCompany);
                if (result) { return StatusCode((int)HttpStatusCode.OK, "Company created successfully !!!"); }
                return StatusCode((int)HttpStatusCode.OK, "Company not created !!!");
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        // PUT: api/JobCategory/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] Company model)
        {
            try
            {
                var entity = _service.GetCompanyById(id);
                if (entity == null) { return NotFound(); }

                if (model.ValidationErrors().Any())
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", model.ValidationErrors()));
                }

                //Update Job category
                entity.Name = model.Name;
                entity.About = model.About;
                entity.UpdatedOn = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(model.LogoUrl)) entity.LogoUrl = model.LogoUrl;

                if (await _service.UpdateCompanyAsync(entity)) { return StatusCode((int)HttpStatusCode.OK, "Company updated successfully !!!"); }
                return StatusCode((int)HttpStatusCode.OK, "Company not updated !!!");
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = _service.GetCompanyById(id);
                if (entity == null) { return NotFound(); }

                if (await _service.DeleteCompanyAsync(entity)) { return StatusCode((int)HttpStatusCode.OK, "Company deleted successfully !!!"); }
                return StatusCode((int)HttpStatusCode.OK, "Company not deleted !!!");
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }
    }
}
