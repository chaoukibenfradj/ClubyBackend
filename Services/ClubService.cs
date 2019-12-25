using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using System.Linq;
namespace clubyApi.Services
{using System.Collections.Generic;
using clubyApi.Repositories;
using MongoDB.Driver;

    public class ClubService :IClubService
    {
        private  readonly IClubRepository _repo;
        public ClubService(IClubRepository repo)
        {
            _repo=repo ;

        }

       public UpdateResult CompleteClubInscription(string id, string institute, string photo)
        {
            return _repo.CompleteClubInscription(id,institute,photo);
        }

        public Club CreateClub(User user)
        {
            return _repo.CreateClub(user);
        }

        public  Club FindClubProfile(string id){
            return _repo.FindClubProfile(id);
        }
      
       
    


   

        
       

        


    }
    
}