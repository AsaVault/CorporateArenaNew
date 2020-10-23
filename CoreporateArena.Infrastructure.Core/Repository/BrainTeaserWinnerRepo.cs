using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure.Core.Repository
{
    public class BrainTeaserWinnerRepo : IRepo<BrainTeaserWinner>
    {
        private readonly TContext _context;
        public BrainTeaserWinnerRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAllByIDAsync(int BTID)
        {
            try
            {
                var answers = await _context.BrainTeaserWinners.Where(x => x.BrainTeaserID == BTID).ToListAsync();
                _context.BrainTeaserWinners.RemoveRange(answers);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task deleteAsync(int ID)
        {
            try
            {
                var bt = await _context.BrainTeaserWinners.FindAsync(ID);
                _context.BrainTeaserWinners.Remove(bt);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BrainTeaserWinner>> getAllAsync()
        {
            try
            {
                var bts = await _context.BrainTeaserWinners.ToListAsync();
                return bts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BrainTeaserWinner>> getAllByIDAsync(int BrainTeaserID)
        {
            try
            {
                var bta = await _context.BrainTeaserWinners.Where(x => x.BrainTeaserID == BrainTeaserID).ToListAsync();
                return bta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BrainTeaserWinner> getAsync(int ID)
        {
            try
            {
                var bt = await _context.BrainTeaserWinners.FindAsync(ID);
                return bt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(BrainTeaserWinner data)
        {

            try
            {
                BrainTeaserWinner bt = new BrainTeaserWinner
                {
                    DateCreated = DateTime.Now,
                    Answer = data.Answer,
                    BrainTeaserID = data.BrainTeaserID,
                    UserCreated = data.UserCreated,
                    UserName = data.UserName,
                    isDisplayed = true
                };

                await _context.BrainTeaserWinners.AddAsync(bt);
                await _context.SaveChangesAsync();
                return bt.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<bool> insertListAsync(List<BrainTeaserWinner> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(BrainTeaserWinner data)
        {
            try
            {
                var bt = await _context.BrainTeaserWinners.FindAsync(data.ID);
                if (bt.isDisplayed)
                {
                    bt.isDisplayed = !bt.isDisplayed;
                }
                else
                {
                    bt.isDisplayed = !bt.isDisplayed;
                }
                _context.BrainTeaserWinners.Update(bt);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
