using clubyApi.Models;
using clubyApi.Repositories;

namespace clubyApi.Services
{
    public class SponsorService:ISponsorService
    {
        private readonly ISponsorRepository _repo;
        public SponsorService(ISponsorRepository repo){
            _repo=repo;
        }

        public Sponsor ChooseInterests(Interest interest)
        {
            throw new System.NotImplementedException();
        }
    }
}