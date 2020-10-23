using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class ArticleCommentRepo : IRepo<ArticleComment>
    {

        private readonly TContext _context;

        public ArticleCommentRepo(TContext context)
        {
            _context = context;
        }

        public async Task deleteAllByIDAsync(int AID)
        {
            try
            {
                var comments = await _context.ArticleComments.Where(x => x.ArticleID == AID).ToListAsync();
                _context.ArticleComments.RemoveRange(comments);
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
                var comment = await _context.ArticleComments.FindAsync(ID);
                _context.ArticleComments.Remove(comment);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ArticleComment>> getAllAsync()
        {
            try
            {
                var comments = await _context.ArticleComments.ToListAsync();
                return comments;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ArticleComment>> getAllByIDAsync(int ArticleID)
        {
            try
            {
                var bta = await _context.ArticleComments.Where(x => x.ArticleID == ArticleID).ToListAsync();
                return bta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ArticleComment> getAsync(int ID)
        {
            try
            {
                var comment = await _context.ArticleComments.FindAsync(ID);
                return comment;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(ArticleComment data)
        {

            try
            {
                ArticleComment comment = new ArticleComment
                {
                    DateCreated = DateTime.Now,
                    Content = data.Content,
                    ArticleID = data.ArticleID,
                    UserCreated = data.UserCreated,
                    Title=data.Title,
                    CommentLikesCount=0
                };
                // This line is not updating
                await _context.ArticleComments.AddAsync(comment);
                await _context.SaveChangesAsync();
                return comment.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<bool> insertListAsync(List<ArticleComment> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(ArticleComment data)
        {
            try
            {
                var comment = await _context.ArticleComments.Where(x => x.ID == data.ID && x.ArticleID == data.ArticleID
                && x.UserCreated==data.UserCreated).SingleOrDefaultAsync();

                comment.DateModified = DateTime.Now;
                if (data.Content != null) comment.Content = data.Content;
                if (data.Title != null) comment.Title = data.Title;
                if (data.CommentLikesCount != 0) comment.CommentLikesCount = data.CommentLikesCount;
                
                _context.ArticleComments.Update(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
