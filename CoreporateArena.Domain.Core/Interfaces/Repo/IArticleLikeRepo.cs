using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IArticleLikeRepo
    {
        
        Task deleteAllByIDAsync(int ID);

        Task deleteAsync(int userID, int articleID);
        
        Task<ArticleLike> getAsync(int userID,int articleID);
        
        Task<int> insertAsync(ArticleLike data);
    }
}
