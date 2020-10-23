using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class ArticleLikeRepo : IArticleLikeRepo
    {

        private readonly TContext _context;
        public ArticleLikeRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAllByIDAsync(int ID)
        {
            try
            {
                var like=await _context.ArticleLikes.FindAsync(ID);
                _context.ArticleLikes.Remove(like);
                await  _context.SaveChangesAsync();


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task deleteAsync(int userID, int articleID)
        {
            try
            {
                var like = await _context.ArticleLikes.Where(x => x.ArticleID == articleID && x.UserCreated == userID).SingleOrDefaultAsync();
                _context.ArticleLikes.Remove(like);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       

        public async Task<ArticleLike> getAsync(int userID, int articleID)
        {
            ArticleLike like;
            try
            {
                like = await _context.ArticleLikes.Where(x =>x.ArticleID == articleID && x.UserCreated == userID).SingleOrDefaultAsync();
                
            }
            catch(Exception ex)
            {
                like = null;
                throw ex;
            }
            return like;
        }

        public async Task<int> insertAsync(ArticleLike data)
        {
            try
            {
                var like = new ArticleLike
                {
                    ArticleID=data.ArticleID,
                    UserCreated=data.UserCreated
                };

                await _context.ArticleLikes.AddAsync(like);
                await _context.SaveChangesAsync();
                return like.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        
        }
    }
}
