using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IInstituteService
    {
        Institut FindInstitutProfile(string id);
        UpdateResult CompleteInstitutInscription(string id,string name,string region);


    }
}