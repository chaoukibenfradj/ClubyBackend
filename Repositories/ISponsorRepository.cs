using System;
using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Driver;

namespace clubyApi
{
    public interface ISponsorRepository
    {
        Sponsor CreateSponsor(User user);
         List<Sponsor>ShowAllSponsors();
         Sponsor FindSponsorProfile(string id);
          Sponsor FindSponsor(string id);
        UpdateResult updateSponsor(UpdateDto updateDto);
         UpdateResult pickInterest(UpdateDto updateDto);
    }
}