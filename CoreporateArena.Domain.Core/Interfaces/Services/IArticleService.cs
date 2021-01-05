using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IArticleService
    {
        Task<SaveResponse> SaveArticleAsync(Article data);
        Task<SaveResponse> SubmitCommentAsync(ArticleComment data);
        Task<List<Article>> getArticlesAsync();
        Task<List<Article>> getApprovedArticlesAsync();
        Task<Article> GetArticleWithCommentsAsync(int ID);
        Task<Article> GetApprovedArticleWithCommentsAsync(int ID);
        Task<SaveResponse> UpdateArticleAsync(Article data);
        Task<SaveResponse> UpdateApprovedArticleAsync(Article data);
        Task<SaveResponse> DeleteArticleAsync(int ID, int userID);
        Task<SaveResponse> LikeArticleAsync(int userID, int articleID);
        Task<SaveResponse> ApproveArticleAsync(int userID, int articleID);
        Task<SaveResponse> LikeCommentAsync(int userID, int articleID, int commentID);
    }
}
