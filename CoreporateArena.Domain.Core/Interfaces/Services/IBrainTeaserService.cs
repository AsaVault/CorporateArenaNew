using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IBrainTeaserService
    {
        Task<SaveResponse> SaveBrainTeaserAsync(BrainTeaser data);
        Task<SaveResponse> SubmitAnswerAsync(BrainTeaserAnswer data);
        Task<BrainTeaser> GetBrainTeaserandAnswerAsync(int ID);
        Task<BrainTeaser> GetBrainTeaserAndWinnerAsync(int ID);
        Task<SaveResponse> ApproveBrainTeaserAnswerAsync(int userID, int wId);
        Task<SaveResponse> DisplayBrainTeaserWinnerAsync(int userID, int wId);
        Task<SaveResponse> UpdateBrainTeaserAsync(BrainTeaser data);
        Task<SaveResponse> DeleteBrainTeaser(int ID,int userID);
        Task<List<BrainTeaser>> getAllAsync();
    }
}
