using System;
using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Repositories;
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

      
        List<Sponsor> ISponsorService.ShowAllSponsors()
        {
            return _repo.ShowAllSponsors();
        }
    }
}