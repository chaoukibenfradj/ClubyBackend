using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi
{
    public interface ISponsorService
    {
      Sponsor CreateSponsor(User user);
      List<Sponsor>ShowAllSponsors();
      Sponsor FindSponsorProfile(string id);
      Sponsor FindSponsor(string id);

    }
}