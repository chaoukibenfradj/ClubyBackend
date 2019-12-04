using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IInstituteRepository
    {
       
        Institut FindInstitutProfile(string id);
        UpdateResult CompleteInstitutInscription(string id,string name,string region);


    }
}