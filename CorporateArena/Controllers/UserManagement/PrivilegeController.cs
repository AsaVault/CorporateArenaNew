using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegeController : ControllerBase
    {
        



        private readonly IPrivilegeService _pService;
        public PrivilegeController(IPrivilegeService pService)
        {
            _pService = pService;
        }


        [HttpPost("CreateAllPrivileges")]
        public async Task<IActionResult> CreateAllPrivileges()
        {

            var result = await _pService.insertListAsync();
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SavePrivilege")]
        public async Task<IActionResult> SavePrivilege(Privilege data)
        {
            var result = await _pService.insertAsync(data);
            return Ok(new { message = "Successful", status = result });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPrivileges")]
        public async Task<IActionResult> GetAllPrivileges()
        {
            var result = await _pService.getAllAsync();
            return Ok(result);

        }

        [HttpGet("GetModels")]
        public IActionResult GetModels()
        {

            
            var result = _pService.GetModelsAsync();
            return Ok(result);


        }
        [HttpGet("GetActions")]
        public IActionResult GetActions()
        {
            // var result = await _repo.GetActionsAsync();
            Models mod = new Models();
            var result = mod.GetActions();
            return Ok(result);
        }


        
    }
}
