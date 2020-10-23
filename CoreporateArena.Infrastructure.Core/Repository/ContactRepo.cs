using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class ContactRepo : IRepo<Contact>
    {
        private readonly TContext _context;
        public ContactRepo(TContext context)
        {
            _context = context;
        }
        public Task deleteAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task deleteAsync(int ID)
        {
            try
            {
                var contact = await _context.Contacts.FindAsync(ID);
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Contact>> getAllAsync()
        {
            try
            {
                var contacts = await _context.Contacts.OrderByDescending(x=>x.DateCreated).ToListAsync();
                return contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Contact>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> getAsync(int ID)
        {
            try
            {
                var contact = await _context.Contacts.FindAsync(ID);
                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(Contact data)
        {
            try
            {
                var contact = new Contact
                {
                    DateCreated = DateTime.Now,
                    Message = data.Message,
                    Username = data.Username,
                    Email = data.Email
                };
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                return contact.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Contact> data)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(Contact data)
        {
            throw new NotImplementedException();
        }
    }
}
