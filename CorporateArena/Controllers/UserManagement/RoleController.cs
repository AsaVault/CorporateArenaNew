using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using CorporateArena.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service) 
        {

            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Authorize]
        [AuthorizePermission(Permissions = Permission.CreateRole)]
        [HttpPost("SaveRole")]
        public async Task<IActionResult> SaveRole(Role data)
        {
            var result = await _service.SaveRoleAsync(data);
            return Ok(result);
        }


        [Authorize]
        [AuthorizePermission(Permissions = Permission.ReadRole)]
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _service.GetAllRolesAsync();
            return Ok(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        [Authorize]
        [AuthorizePermission(Permissions = Permission.ReadRole)]
        [HttpGet("GetRoleByID/{ID}")]
        public async Task<IActionResult> GetRoleByID(int ID)
        {
            var result = await _service.GetRoleByIDAsync(ID);
            return Ok(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="privilegeID"></param>
        /// <returns></returns>

        [Authorize]
        [AuthorizePermission(Permissions = Permission.AssignPrivilegeToRole)]
        [HttpPost("AssignPrivilegetoRole/{roleID}/{privilegeID}")]
        public async Task<IActionResult> AssignPrivilegetoRole(int roleID, int privilegeID)
        {
            var result = await _service.AssignPrivilegetoRoleAsync(roleID, privilegeID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRolePrivileges")]
        public async Task<IActionResult> GetAllRolePrivileges()
        {
            var result = await _service.GetAllRolePrivileges();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateSuperUserRole")]
        public async Task<IActionResult> CreateSuperUserRole()
        {
            var result = await _service.SaveSuperUser();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateBasicRole")]
        public async Task<IActionResult> CreateBasicRole()
        {
            var result = await _service.SaveBasicRole();
            return Ok(result);
        }
    }
}
