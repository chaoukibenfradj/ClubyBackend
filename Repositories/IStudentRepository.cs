using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IStudentRepository
    {
        Student FindStudentByEmail(string email);
        Student FindStudentProfile(string id);
        UpdateResult CompleteStudentInscription(string id,string institute,string photo);


    }
}