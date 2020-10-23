using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class BrainTeaserAnswerRepo : IRepo<BrainTeaserAnswer>
    {

        private readonly TContext _context;

        public BrainTeaserAnswerRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAllByIDAsync(int BTID)
        {
            try
            {
                var answers = await _context.BrainTeaserAnswers.Where(x => x.BrainTeaserID == BTID).ToListAsync();
                _context.BrainTeaserAnswers.RemoveRange(answers);
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
                var bt = await _context.BrainTeaserAnswers.FindAsync(ID);
                _context.BrainTeaserAnswers.Remove(bt);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BrainTeaserAnswer>> getAllAsync()
        {
            try
            {
                var bts = await _context.BrainTeaserAnswers.ToListAsync();
                return bts;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BrainTeaserAnswer>> getAllByIDAsync(int BrainTeaserID)
        {
            try
            {
                var bta = await _context.BrainTeaserAnswers.Where(x => x.BrainTeaserID == BrainTeaserID).AsQueryable().ToListAsync();
                return bta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BrainTeaserAnswer> getAsync(int ID)
        {
            try
            {
                var bt = await _context.BrainTeaserAnswers.FindAsync(ID);
                return bt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(BrainTeaserAnswer data)
        {

            try
            {
                BrainTeaserAnswer bt = new BrainTeaserAnswer
                {
                    DateCreated = DateTime.Now,
                    Answer = data.Answer,
                    BrainTeaserID = data.BrainTeaserID,
                    UserCreated = data.UserCreated,
                    UserName = data.UserName
                };

                await _context.BrainTeaserAnswers.AddAsync(bt);
                await _context.SaveChangesAsync();
                return bt.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<bool> insertListAsync(List<BrainTeaserAnswer> data)
        {
            throw new NotImplementedException();
        }

        // Here we approve brain teaser answer and add to brain teaser winner
        public async Task updateAsync(BrainTeaserAnswer data)
        {
            try
            {
                //var bAnswer = await _context.BrainTeaserAnswers.FindAsync(data.ID);
                //if (data.isApproved == false) bAnswer.isApproved = true;
                // _context.BrainTeaserAnswers.Update(bAnswer);
                if (data.isApproved == false) data.isApproved = true;

                _context.BrainTeaserAnswers.Update(data);

                var bWinner = new BrainTeaserWinner()
                {
                    DateCreated = data.DateCreated,
                    UserCreated = data.UserCreated,
                    UserName = data.UserName,
                    Answer = data.Answer,
                    isDisplayed = true,
                    BrainTeaserID = data.BrainTeaserID
                };
                _context.BrainTeaserWinners.Add(bWinner);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
