using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IStudentService
    {
        Student FindStudentProfile(string id);
        UpdateResult CompleteStudentInscription(string id,string institute,string photo);


    }
}