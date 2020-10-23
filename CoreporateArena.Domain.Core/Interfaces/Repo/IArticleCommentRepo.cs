//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace CorporateArena.Domain
//{
//    public interface IArticleCommentRepo
//    {
//        Task<ArticleComment> getSingleCommentAsync(int articleID, int commentID);

//        Task UpdateCommentAsync(int articleID, int commentID);

//        public async Task deleteAllByIDAsync(int AID)
//        {
//            try
//            {
//                var comments = await _context.ArticleComments.Where(x => x.ArticleID == AID).ToListAsync();
//                _context.ArticleComments.RemoveRange(comments);
//                await _context.SaveChangesAsync();

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public async Task deleteAsync(int ID)
//        {
//            try
//            {
//                var comment = await _context.ArticleComments.FindAsync(ID);
//                _context.ArticleComments.Remove(comment);
//                await _context.SaveChangesAsync();

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public async Task<List<ArticleComment>> getAllAsync()
//        {
//            try
//            {
//                var comments = await _context.ArticleComments.ToListAsync();
//                return comments;

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public async Task<List<ArticleComment>> getAllByIDAsync(int ArticleID)
//        {
//            try
//            {
//                var bta = await _context.ArticleComments.Where(x => x.ArticleID == ArticleID).ToListAsync();
//                return bta;

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public async Task<ArticleComment> getAsync(int ID)
//        {
//            try
//            {
//                var comment = await _context.ArticleComments.FindAsync(ID);
//                return comment;

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public async Task<int> insertAsync(ArticleComment data)
//        {

//            try
//            {
//                ArticleComment comment = new ArticleComment
//                {
//                    DateCreated = DateTime.Now,
//                    Content = data.Content,
//                    ArticleID = data.ArticleID,
//                    UserCreated = data.UserCreated,
//                    Title = data.Title,
//                    CommentLikesCount = 0
//                };

//                await _context.ArticleComments.AddAsync(comment);
//                await _context.SaveChangesAsync();
//                return comment.ID;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }

//        public Task<bool> insertListAsync(List<ArticleComment> data)
//        {
//            throw new NotImplementedException();
//        }

//        public Task updateAsync(ArticleComment data)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
