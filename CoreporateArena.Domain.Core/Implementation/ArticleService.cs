using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class ArticleService : IArticleService
    {

        private readonly IUserService _uService;
        private readonly IArticleRepo _repo;
        private readonly IRepo<ArticleComment> _cRepo;
        private readonly IArticleLikeRepo _alRepo;
        private readonly ICommentLikeRepo _clRepo;

        public ArticleService(IUserService uService, IArticleRepo repo, IRepo<ArticleComment> cRepo, IArticleLikeRepo alRepo, ICommentLikeRepo clRepo)
        {
            _uService = uService;
            _repo = repo;
            _cRepo = cRepo;
            _alRepo = alRepo;
            _clRepo = clRepo;
        }


        public async Task<SaveResponse> SaveArticleAsync(Article data)
        {
            //var userExist = await _uService.CheckIfUserExist(data.AuthorID);
            //if (!userExist)
            //    return new SaveResponse { status = false, Result = "User Not Found" };

            //string name = "CreateArticle";
            //var permission = await _uService.CheckforPermission(data.AuthorID, name);

            //if (!permission)
            //    return new SaveResponse { Result = "User does not have permission to perform this action" };

            int AID = await _repo.insertAsync(data);
            return new SaveResponse { ID = AID, status = true, Result = "Article successfully created" };
        }

        public async Task<List<Article>> getAllAsync()
        {
            var result = await _repo.getAllAsync();
            return result;
        }

        public async Task<SaveResponse> SubmitCommentAsync(ArticleComment data)
        {

            int CID = await _cRepo.insertAsync(data);
            return new SaveResponse { ID = CID, status = true, Result = "Comment successfully submitted" };


        }
        public async Task<Article> GetArticleWithCommentsAsync(int ID)
        {
            var article = await _repo.getAsync(ID);

            var comments = await _cRepo.getAllByIDAsync(ID);
            if (comments != null && comments.Count > 0)
                article.Comments = comments;

            return article;
        }
        public async Task<SaveResponse> UpdateArticleAsync(Article data)
        {
            //var userExist = await _uService.CheckIfUserExist(data.AuthorID);
            //if (!userExist)
            //    return new SaveResponse { status = false, Result = "User Not Found" };

            //string name = "UpdateArticle";
            //var permission = await _uService.CheckforPermission(data.AuthorID, name);

            //if (!permission)
            //    return new SaveResponse { Result = "User does not have permission to perform this action" };

            await _repo.updateAsync(data);
            return new SaveResponse { status = true, Result = "Article successfully updated" };

        }

        public async Task<SaveResponse> DeleteArticleAsync(int ID, int userID)
        {

            //var userExist = await _uService.CheckIfUserExist(userID);
            //if (!userExist)
            //    return new SaveResponse { status = false, Result = "User Not Found" };

            //string name = "DeleteArticle";
            //var permission = await _uService.CheckforPermission(userID, name);

            //if (!permission)
            //    return new SaveResponse { Result = "User does not have permission to perform this action" };

            var comments = await _cRepo.getAllByIDAsync(ID);
            if (comments != null)
                await _cRepo.deleteAllByIDAsync(ID);

            await _repo.deleteAsync(ID);

            return new SaveResponse { status = true, Result = "Article successfully deleted" };
        }


        // Approve Article 
        public async Task<SaveResponse> ApproveArticleAsync(int userID, int articleID)
        {
            var article = await _repo.getUnappproveAsync(articleID);

            if (article != null && userID == 1 || userID == 2)
            {
                article.isApproved = true;
                await _repo.updateApproveAsync(article);
                return new SaveResponse { status = true, Result = "Article was approved" };
            }
            else
            {
                return new SaveResponse { status = true, Result = "Unable to approve article" };
            }
        }

        public async Task<SaveResponse> LikeArticleAsync(int userID, int articleID)
        {
            var article = await _repo.getAsync(articleID);

            // check if the userid and articleid exist in articleLike

            var like = await _alRepo.getAsync(userID, articleID);

            // Increase articlelikeCount and save articleLike, if it hasn't been liked before
            if (like == null)
            {
                var newLike = new ArticleLike
                {
                    ArticleID = articleID,
                    UserCreated = userID
                };
                await _alRepo.insertAsync(newLike);
                article.ArticleLikesCount += 1;
                await _repo.updateAsync(article);
                return new SaveResponse { status = true, Result = "Article was liked" };
            }
            else
            {
                await _alRepo.deleteAsync(userID, articleID);
                article.ArticleLikesCount -= 1;
                await _repo.updateAsync(article);
                return new SaveResponse { status = true, Result = "Article was unliked" };
            }


        }

        public async Task<SaveResponse> LikeCommentAsync(int userID, int articleID, int commentID)
        {


            var articleComment = await _repo.getSingleCommentAsync(userID, articleID, commentID);

            // check if the userid and articleid,commentid exist in commentLike

            var like = await _clRepo.getAsync(userID, articleID, commentID);

            // Increase commentlikeCount and save commentLike, if it hasn't been liked before
            if (like == null)
            {
                var newLike = new CommentLike
                {
                    CommentID = commentID,
                    UserCreated = userID,
                    ArticleID = articleID
                };
                await _clRepo.insertAsync(newLike);
                articleComment.CommentLikesCount += 1;
                await _cRepo.updateAsync(articleComment);
                return new SaveResponse { status = true, Result = "Comment was liked" };
            }

            else
            {
                await _clRepo.deleteAsync(userID, articleID, commentID);
                articleComment.CommentLikesCount -= 1;
                await _cRepo.updateAsync(articleComment);
                return new SaveResponse { status = true, Result = "Comment was unliked" };
            }


        }
    }
}
