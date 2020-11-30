using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CorporateArena.Domain.Core.Entities;
using CorporateArena.Domain.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IJobCategoryService _service;

        public JobCategoryController(IJobCategoryService service)
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
                var jobCategories = await _service.GetJobCategoryByPageAsync(page, pageSize);
                return StatusCode((int)HttpStatusCode.OK, jobCategories);
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
                var jobCategories = _service.GetAllJobCategories();
                return StatusCode((int)HttpStatusCode.OK, jobCategories);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        // Get: api/GetById
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var jobCategory = _service.GetJobCategoryById(id);
                return StatusCode((int)HttpStatusCode.OK, jobCategory);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
            
        }
        // POST: api/CreateAsync
        [HttpPost("")]
        public async Task<IActionResult> CreateAsync([FromBody] JobCategory model)
        {
            try
            {
                if (model.ValidationErrors().Any())
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", model.ValidationErrors()));
                }

                var newJobCategory = new JobCategory
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsDisplayed = true,
                    IsDeleted = false
                };

                var result = await _service.AddJobCategoryAsync(newJobCategory);
                if (result) { return StatusCode((int)HttpStatusCode.OK, "Job Category created successfully !!!"); }
                return StatusCode((int)HttpStatusCode.OK, "Job Category not created !!!");
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        // PUT: api/JobCategory/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JobCategory model)
        {
            try
            {
                var entity = _service.GetJobCategoryById(id);
                if(entity == null) { return NotFound(); }

                if (model.ValidationErrors().Any())
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", model.ValidationErrors()));
                }

                //Update Job category
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.UpdatedOn = DateTime.Now;

                if(await _service.UpdateJobCategoryAsync(entity)) { return StatusCode((int)HttpStatusCode.OK, "Job category updated successfully !!!"); }
                return StatusCode((int)HttpStatusCode.OK, "Job category not updated !!!");
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = _service.GetJobCategoryById(id);
                if(entity == null) { return NotFound(); }

                if(await _service.DeleteJobCategoryAsync(entity)) { return StatusCode((int)HttpStatusCode.OK, "Job category deleted successfully !!!"); }
                return StatusCode((int)HttpStatusCode.OK, "Job category not deleted !!!");
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }
    }
}
