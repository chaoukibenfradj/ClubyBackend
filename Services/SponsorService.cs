using clubyApi.Models;

namespace clubyApi
{
    public class SponsorService : ISponsorService
    {
        private  readonly ISponsorRepository _repo;
        public SponsorService(ISponsorRepository repo)
        {
            _repo=repo ;

        }
        public Sponsor CreateSponsor(User user)
        {
            return _repo.CreateSponsor(user);
        }

        public List<Sponsor> FindAllSponsors()
        {
           return _repo.FindAllSponsors();
        }
    }
}