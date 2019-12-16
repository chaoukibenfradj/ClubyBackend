using clubyApi.Models;

namespace clubyApi
{
    public interface ISponsorRepository
    {
        Sponsor CreateSponsor(User user);

    }
}