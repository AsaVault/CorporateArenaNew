using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface ITrafficUpdateService
    {
        Task<SaveResponse> SaveTrafficUpdateAsync(TrafficUpdate data);

        Task<SaveResponse> SaveTrafficUpdateCommentAsync(TrafficComment data);

        Task<TrafficUpdate> GetTrafficUpdateWithComments(int ID);

        Task<SaveResponse> DeleteArticleAsync(int ID, int userID);
        Task<List<TrafficUpdate>> getAllAsync();



    }
}
