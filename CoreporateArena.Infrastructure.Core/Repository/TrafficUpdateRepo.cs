using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class TrafficUpdateRepo : IRepo<TrafficUpdate>
    {

        private readonly TContext _context;

        public TrafficUpdateRepo(TContext context)
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
                var trafficUpdate = await _context.TrafficUpdates.FindAsync(ID);
                _context.TrafficUpdates.Remove(trafficUpdate);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<TrafficUpdate>> getAllAsync()
        {
            try
            {
                var trafficUpdates = await _context.TrafficUpdates.OrderByDescending(x => x.DateCreated).ToListAsync();
                return trafficUpdates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TrafficUpdate>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<TrafficUpdate> getAsync(int ID)
        {
            try
            {
                var trafficUpdate = await _context.TrafficUpdates.Include(x => x.TrafficUpdateComments).FirstOrDefaultAsync(x => x.ID == ID);
                return trafficUpdate;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(TrafficUpdate data)
        {
            try
            {
                var trafficUpdate = new TrafficUpdate
                {
                    DateCreated = DateTime.Now,
                    Description = data.Description,
                    Title = data.Title,
                    UserCreated = data.UserCreated
                };

                await _context.TrafficUpdates.AddAsync(trafficUpdate);
                await _context.SaveChangesAsync();

                return trafficUpdate.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<TrafficUpdate> data)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(TrafficUpdate data)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var trafficUpdate = await _context.TrafficUpdates.FindAsync(data.ID);

                
            //    if (data.Title != null) trafficUpdate.Title = data.Title;
            //    if (data.Description != null) trafficUpdate.Description = data.Title;


            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}

        }
    }
}
