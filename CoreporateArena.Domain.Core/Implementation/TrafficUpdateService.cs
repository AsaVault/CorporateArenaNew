using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class TrafficUpdateService: ITrafficUpdateService
    {
        private readonly IRepo<TrafficComment> _cRepo;
        private readonly IRepo<TrafficUpdate> _uRepo;
        private readonly IUserService _uService;

        public TrafficUpdateService(IRepo<TrafficComment> cRepo,IRepo<TrafficUpdate> uRepo, IUserService uService)
        {
            _cRepo = cRepo;
            _uRepo = uRepo;
            _uService = uService;
        }

        public async Task<TrafficUpdate> GetTrafficUpdateWithComments(int ID)
        {
            var trafficUpdate = await _uRepo.getAsync(ID);

            var comments = await _cRepo.getAllByIDAsync(ID);
            if (comments != null)
                trafficUpdate.TrafficUpdateComments = comments;

            return trafficUpdate;
        }

        public async Task<List<TrafficUpdate>> getAllAsync()
        {
            var result = await _uRepo.getAllAsync();
            return result;
        }

        public async Task<SaveResponse> SaveTrafficUpdateAsync(TrafficUpdate data)
        {
            int TID = await _uRepo.insertAsync(data);
            return new SaveResponse { ID = TID, status = true, Result = "Traffic Update successfully created" };
        }

        public async Task<SaveResponse> SaveTrafficUpdateCommentAsync(TrafficComment data)
        {
            
            int CID = await _cRepo.insertAsync(data);
            return new SaveResponse { ID = CID, status = true, Result = "Comment successfully submitted" };
        }

        public async Task<SaveResponse> DeleteArticleAsync(int ID, int userID)
        {

           

            var comments = await _cRepo.getAllByIDAsync(ID);
            if (comments != null)
                await _cRepo.deleteAllByIDAsync(ID);

            await _uRepo.deleteAsync(ID);


            return new SaveResponse { status = true, Result = "Traffic Update successfully deleted" };

        }

    }
}
