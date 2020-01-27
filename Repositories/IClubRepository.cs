using System;
using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Driver;
namespace clubyApi.Repositories
{
    public interface IClubRepository
    {   
        Club CreateClub(User user,Institute institute,Domain domain);
        Club FindClubProfile(string id);
        UpdateResult CompleteClubInscription(string id,string institute,string photo);
        Club DeleteClub(string id);
        Club FindClub(string id);
        List<Club>ShowAllClubs();

    }
}