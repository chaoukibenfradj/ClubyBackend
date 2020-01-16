using System;
using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi
{
    public interface ISponsorRepository
    {
        Sponsor CreateSponsor(User user);
         List<Sponsor>ShowAllSponsors();
         Sponsor FindSponsorProfile(string id);
          Sponsor FindSponsor(string id);
    }
}