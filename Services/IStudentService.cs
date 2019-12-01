using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IStudentService
    {
        Student AuthentificateStudent(string email,string password);
        Inscription CreateStudent(Inscription student);
        Student FindStudentProfile(string id);
        UpdateResult CompleteStudentInscription(string id,string institute,string photo);


    }
}