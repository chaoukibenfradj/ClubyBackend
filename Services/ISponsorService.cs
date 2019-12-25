using clubyApi.Models;

namespace clubyApi
{
    public interface ISponsorService
    {
      Sponsor CreateSponsor(User user);
      public List<Sponsor> FindAllSponsors();

    }
}