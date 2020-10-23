using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class BrainTeaserRepo : IRepo<BrainTeaser>
    {

        private readonly TContext _context;
        public BrainTeaserRepo(TContext context)
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
                var bt = await _context.BrainTeasers.FindAsync(ID);
                _context.BrainTeasers.Remove(bt);
                await _context.SaveChangesAsync();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BrainTeaser>> getAllAsync()
        {
            try
            {
                var bts = await _context.BrainTeasers.OrderByDescending(x=>x.DateCreated).Include(x=>x.BrainTeaserAnswers).Include(x => x.BrainTeaserWinners).ToListAsync();
                return bts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<BrainTeaser>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<BrainTeaser> getAsync(int ID)
        {
            try
            {
                var bt = await _context.BrainTeasers.FindAsync(ID);
                return bt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(BrainTeaser data)
        {
            
            try
            {
                BrainTeaser bt = new BrainTeaser
                {
                    DateCreated=DateTime.Now,
                    Riddle=data.Riddle,
                    UserCreated=data.UserCreated,
                    CorrectAnswer=data.CorrectAnswer
                };

                await _context.BrainTeasers.AddAsync(bt);
                await _context.SaveChangesAsync();
                return bt.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<bool> insertListAsync(List<BrainTeaser> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(BrainTeaser data)
        {
            try
            {
                var bt = await _context.BrainTeasers.FindAsync(data.ID);
                if (data.Riddle != null) bt.Riddle = data.Riddle;
                bt.DateModified = data.DateModified;

                _context.BrainTeasers.Update(bt);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
