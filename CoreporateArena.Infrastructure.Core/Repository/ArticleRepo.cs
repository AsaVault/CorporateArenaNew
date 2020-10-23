using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class ArticleRepo : IArticleRepo
    {
        private readonly TContext _context;
        public ArticleRepo(TContext context)
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
                var article = await _context.Articles.FindAsync(ID);
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Article>> getAllAsync()
        {
            try
            {
                var articles = await _context.Articles.Include(x=>x.Comments).Where(x=>x.isApproved == true).OrderByDescending(x=>x.DateCreated).ToListAsync();
                return articles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Article>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleComment> getSingleCommentAsync(int userID,int articleID, int commentID)
        {
            
            try
            {
                var comment = await _context.ArticleComments.Where(x => x.ID == commentID && x.ArticleID == articleID
                && x.UserCreated==userID).SingleAsync();

                return comment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Article> getAsync(int ID)
        {
            try
            {
                var article = await _context.Articles.Where(x => x.ID == ID && x.isApproved == true).SingleOrDefaultAsync();
                //var article = await _context.Articles.Where(x => x.ID == ID).SingleOrDefaultAsync();
                return article;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GetUnApprove Article
        public async Task<Article> getUnappproveAsync(int ID)
        {
            try
            {
                //var article = await _context.Articles.Where(x => x.ID == ID && x.isApproved == true).SingleOrDefaultAsync();
                var article = await _context.Articles.Where(x => x.ID == ID && x.isApproved ==false).SingleOrDefaultAsync();
                return article;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> insertAsync(Article data)
        {
            try
            {
                var article = new Article
                {
                    DateCreated = DateTime.Now,
                    AuthorID = data.AuthorID,
                    Content = data.Content,
                    ImageUrl = data.ImageUrl,
                    Title = data.Title,
                    ArticleLikesCount = 0,
                    isApproved = false,
                };

                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
                return article.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> insertListAsync(List<Article> data)
        {
            throw new NotImplementedException();
        }

        public async Task updateAsync(Article data)
        {
            try
            {
                var article = await _context.Articles.Where(x => x.ID == data.ID && x.isApproved == true).SingleOrDefaultAsync();

                article.DateModified = DateTime.Now;
                    if (data.Content != null) article.Content = data.Content;
                    if (data.ImageUrl != null) article.ImageUrl = data.ImageUrl;
                    if (data.Title != null) article.Title = data.Title;
                    article.isApproved = data.isApproved;
                    if (data.ArticleLikesCount != 0) article.ArticleLikesCount = data.ArticleLikesCount;

                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Update Approve Async
        public async Task updateApproveAsync(Article data)
        {
            try
            {
                var article = await _context.Articles.Where(x => x.ID == data.ID && x.isApproved == false).SingleOrDefaultAsync();

                article.isApproved = data.isApproved;

                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
