using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface ICommentLikeRepo
    {
        Task deleteAllByIDAsync(int ID);

        Task deleteAsync(int userID, int articleID, int commentID);

        Task<CommentLike> getAsync(int userID,int articleID, int commentID);

        Task<int> insertAsync(CommentLike data);
    }
}
