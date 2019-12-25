using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IClubService
    {  
        Club CreateClub(User user);
        Club FindClubProfile(string id);
        UpdateResult CompleteClubInscription(string id,string institute,string photo);


    }
}