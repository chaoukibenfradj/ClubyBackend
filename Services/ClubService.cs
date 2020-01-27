using System;
using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Repositories;
using ClubyBackend.Models;
using MongoDB.Driver;



namespace clubyApi.Services
{
  

    public class ClubService :IClubService
    {
        private  readonly IClubRepository _repo;
        public ClubService(IClubRepository repo)
        {
            _repo=repo ;

        }
        public Club FindClub(string id){
            return _repo.FindClub(id);
        }


      public UpdateResult CompleteClubInscription(string id, string institute, string photo)
     {
         return _repo.CompleteClubInscription(id,institute,photo);
     }

   
     public Club CreateClub(User user,Institute institute,Domain domain)
     {
         return _repo.CreateClub(user, institute, domain);
    }

       

        public  Club FindClubProfile(string id){
            return _repo.FindClubProfile(id);
        }

        List<Club> IClubService.ShowAllClubs()
        {
            return _repo.ShowAllClubs();
        }

        
        public Club DeleteClub(string id)
        {
            return _repo.DeleteClub(id);
        }
    }}