using CorporateArena.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Presentation
{
    public interface IEmailSender
    {
        Task ActivateAccountAsync(string username, string email,int id);

        Task SendUserMessage(ContactEmail email);
    }
}
