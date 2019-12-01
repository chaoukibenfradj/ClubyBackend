using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IStudentRepository
    {
        Inscription CreateStudent(Inscription student);
        Student AuthentificateStudent(string email,string password);
        Student FindStudentByEmail(string email);
        Student FindStudentProfile(string id);
        UpdateResult CompleteStudentInscription(string id,string institute,string photo);


    }
}