using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class BrainTeaserService : IBrainTeaserService
    {
        private readonly IRepo<BrainTeaser> _repo;
        private readonly IUserService _uService;
        private readonly IRepo<BrainTeaserAnswer> _bRepo;
        private readonly IRepo<BrainTeaserWinner> _wRepo;

        public BrainTeaserService(IRepo<BrainTeaser> repo, IUserService uService, IRepo<BrainTeaserAnswer> bRepo, IRepo<BrainTeaserWinner> wRepo)
        {
            _repo = repo;
            _uService = uService;
            _bRepo = bRepo;
            _wRepo = wRepo;
        }

        public async Task<SaveResponse> SaveBrainTeaserAsync(BrainTeaser data)
        {
            int BRID = await _repo.insertAsync(data);
            return new SaveResponse { ID = BRID, status = true, Result = "Brain Teaser successfully created" };
        }

        public async Task<List<BrainTeaser>> getAllAsync()
        {
            var result = await _repo.getAllAsync();
            return result;
        }


        public async Task<SaveResponse> SubmitAnswerAsync(BrainTeaserAnswer data)
        {
            

            int AID = await _bRepo.insertAsync(data);
            return new SaveResponse { ID = AID, status = true, Result = "Answer successfully submitted" };
        }

        // This should be reviewed if it should be left or deleted...
        public async Task<SaveResponse> SubmitWinnerAsync(BrainTeaserWinner data)
        {
            int WID = await _wRepo.insertAsync(data);
            return new SaveResponse { ID = WID, status = true, Result = "Winner successfully submitted" };
        }

        // Get Brain teaser with winner and answer list only for Admin
        public async Task<BrainTeaser> GetBrainTeaserandAnswerAsync(int ID)
        {
            var bt = await _repo.getAsync(ID);

            var answers = await _bRepo.getAllByIDAsync(ID);
            var winners = await _wRepo.getAllByIDAsync(ID);
            bt.BrainTeaserAnswers = answers;
            bt.BrainTeaserWinners = winners;

            return bt;
        }

        // Get Brain teaser with winner list only
        public async Task<BrainTeaser> GetBrainTeaserAndWinnerAsync(int ID)
        {
            var bt = await _repo.getAsync(ID);

            //var answers = await _bRepo.getAllByIDAsync(ID);
            var winners = await _wRepo.getAllByIDAsync(ID);
            //bt.BrainTeaserAnswers = answers;
            if (winners != null) bt.BrainTeaserWinners = winners;

            return bt;
        }

        // Approve Brain Teaser Answer 
        public async Task<SaveResponse> ApproveBrainTeaserAnswerAsync(int userID, int aId)
        {
            var bAnswer = await _bRepo.getAsync(aId);
            
            if (bAnswer != null && userID == 1 || userID == 2)
            {
                if(bAnswer.isApproved == false) await _bRepo.updateAsync(bAnswer);

                return new SaveResponse { status = true, Result = "Brain teaser answer was approved" };
            }
            else
            {
                return new SaveResponse { status = true, Result = "Unable to approve brain teaser answer" };
            }
        }

        // Display Brain Teaser Winner 
        public async Task<SaveResponse> DisplayBrainTeaserWinnerAsync(int userID, int wId)
        {
            var bWinner = await _wRepo.getAsync(wId);

            if (bWinner != null && userID == 1 || userID == 2)
            {
                if (bWinner.isDisplayed)
                {
                    await _wRepo.updateAsync(bWinner);

                    return new SaveResponse { status = true, Result = "Brain teaser winner was undisplayed" };
                }
                await _wRepo.updateAsync(bWinner);

                return new SaveResponse { status = true, Result = "Brain teaser winner was displayed" };
            }
            else
            {
                return new SaveResponse { status = true, Result = "Unable to approve brain teaser answer" };
            }
        }


        public async Task<SaveResponse> UpdateBrainTeaserAsync(BrainTeaser data)
        {
            
            await _repo.updateAsync(data);
            return new SaveResponse {  status = true, Result = "Brain Teaser successfully updated" };

        }

        public async Task<SaveResponse> DeleteBrainTeaser(int ID,int userID)
        {

           

            var answers = await _bRepo.getAllByIDAsync(ID);
            if(answers!=null)
                await _bRepo.deleteAllByIDAsync(ID);

            await _repo.deleteAsync(ID);

            
            return new SaveResponse { status = true, Result = "Brain Teaser successfully deleted" };

        }
    }
}
