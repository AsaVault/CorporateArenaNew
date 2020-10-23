using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class CommentLikeRepo : ICommentLikeRepo
    {

        private readonly TContext _context;
        public CommentLikeRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAllByIDAsync(int ID)
        {
            try
            {
                var like = await _context.CommentLikes.FindAsync(ID);
                _context.CommentLikes.Remove(like);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task deleteAsync(int userID,int articleID, int CommentID)
        {
            try
            {
                var like = await _context.CommentLikes.Where(x => x.CommentID == CommentID && x.ArticleID==articleID
                && x.UserCreated == userID).SingleOrDefaultAsync();
                _context.CommentLikes.Remove(like);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<CommentLike> getAsync(int userID,int articleID, int CommentID)
        {
            CommentLike like;
            try
            {
                like = await _context.CommentLikes.Where(x => x.CommentID == CommentID && x.ArticleID==articleID && x.UserCreated == userID).SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {
                like = null;
            }
            return like;
        }

        public async Task<int> insertAsync(CommentLike data)
        {
            try
            {
                var like = new CommentLike
                {
                    CommentID = data.CommentID,
                    UserCreated = data.UserCreated,
                    ArticleID=data.ArticleID
                };

                await _context.CommentLikes.AddAsync(like);
                await _context.SaveChangesAsync();
                return like.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
