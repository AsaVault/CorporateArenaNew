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
    public class TrafficUpdateController : ControllerBase
    {

        private readonly ITrafficUpdateService _service;

        public TrafficUpdateController(ITrafficUpdateService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ///[Authorize]
        //[AuthorizePermission(Permissions = Permission.CreateTrafficUpdate)]
        [HttpPost("SaveTrafficUpdate")]
        public async Task<IActionResult> SaveTrafficUpdate(TrafficUpdate data)
        {
            var result = await _service.SaveTrafficUpdateAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadTrafficUpdate)]
        [HttpGet("GetAllTrafficUpdates")]
        public async Task<IActionResult> GetAllTrafficUpdates()
        {
            var result = await _service.getAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.UpdateTrafficUpdate)]
        [HttpGet("GetTrafficUpdate/{ID}")]
        public async Task<IActionResult> GetTrafficUpdate(int ID)
        {
            var result = await _service.GetTrafficUpdateWithComments(ID);
            return Ok(result);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("CommentOnTrafficUpdate")]
        public async Task<IActionResult> CommentOnTrafficUpdate(TrafficComment data)
        {
            var result = await _service.SaveTrafficUpdateCommentAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UpdateTrafficID"></param>
        /// <returns></returns>
        [Authorize]
        [AuthorizePermission(Permissions = Permission.UpdateTrafficUpdate)]
        [HttpDelete("DeleteTrafficUpdate/{UserID}/{UpdateTrafficID}")]
        public async Task<IActionResult> DeleteTrafficUpdate(int UserID, int UpdateTrafficID)
        {
            var result = await _service.DeleteArticleAsync(UpdateTrafficID, UserID);
            return Ok(result);
        }

    }
}
