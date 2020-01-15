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

        public Sponsor FindSponsorProfile(string id)
        {
            return _repo.FindSponsorProfile(id);
        }

        List<Sponsor> ISponsorService.ShowAllSponsors()
        {
            return _repo.ShowAllSponsors();
        }
    }
}