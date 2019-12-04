using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IClubRepository
    {
        Club FindClubByEmail(string email);
        Club FindClubProfile(string id);
        UpdateResult CompleteClubInscription(string id,string institute,string photo);


    }
}