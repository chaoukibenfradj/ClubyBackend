using System;
using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IClubService
    {  
        
       Club CreateClub(User user,Institute institute,Domain domain);
        Club FindClubProfile(string id);
       UpdateResult CompleteClubInscription(UpdateDto club);
        Club FindClub(string id);
        List<Club>ShowAllClubs();
        Club DeleteClub(string id);



    }
}