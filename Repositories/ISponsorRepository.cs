using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface ISponsorRepository
    {
        public Sponsor ChooseInterests(Interest interest);
    }
}