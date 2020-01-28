using System;
using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Repositories;
using ClubyBackend.Models;
using MongoDB.Driver;

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
        public  Sponsor FindSponsor(string id){
            return _repo.FindSponsor(id);
        }

        List<Sponsor> ISponsorService.ShowAllSponsors()
        {
            return _repo.ShowAllSponsors();
        }
        public  UpdateResult updateSponsor(UpdateDto updateDto){
            return _repo.updateSponsor(updateDto);
            
        }
        public UpdateResult pickInterest (UpdateDto sponsor){
            return _repo.pickInterest(sponsor);
        }
    }
}