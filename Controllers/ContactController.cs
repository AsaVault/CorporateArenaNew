using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepo<Contact> _repo;
        private readonly IEmailSender _sender;

        public ContactController(IRepo<Contact> repo, IEmailSender sender)
        {
            _repo = repo;
            _sender = sender;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(Contact data)
        {

            // this needs to be optimized
            var result = await _repo.insertAsync(data);
            var email = new ContactEmail
            {
                Message = data.Message,
                Email = data.Email,
                Username = data.Username
            };
           await _sender.SendUserMessage(email);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);
        }
    }
}
