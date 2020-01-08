using System;
using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi
{
    public interface ISponsorRepository
    {
        Sponsor CreateSponsor(User user);
        List<Sponsor>ShowAllSponsors();
    }
}