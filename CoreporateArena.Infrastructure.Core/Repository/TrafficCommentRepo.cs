using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class TrafficCommentRepo : IRepo<TrafficComment>
    {

        private readonly TContext _context;

        public TrafficCommentRepo(TContext context)
        {
            _context = context;
        }


        public async  Task deleteAllByIDAsync(int ID)
        {
            try
            {
                var comments = await _context.TrafficComments.Where(x => x.TrafficUpdateID == ID).ToListAsync();
                _context.TrafficComments.RemoveRange(comments);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task deleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<TrafficComment>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TrafficComment>> getAllByIDAsync(int ID)
        {
            try
            {
                var comments=await _context.TrafficComments.Where(x => x.TrafficUpdateID == ID).ToListAsync();
                return comments;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<TrafficComment> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> insertAsync(TrafficComment data)
        {
            try
            {
                var comment = new TrafficComment
                {
                    DateCreated = DateTime.Now,
                    Comment=data.Comment,
                    TrafficUpdateID=data.TrafficUpdateID,
                    UserCreated = data.UserCreated
                };

                await _context.TrafficComments.AddAsync(comment);
                await _context.SaveChangesAsync();

                return comment.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<TrafficComment> data)
        {
            throw new NotImplementedException();
        }

        public Task updateAsync(TrafficComment data)
        {
            throw new NotImplementedException();
        }
    }
}
