using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface IStudentRepository
    {
        Inscription CreateStudent(Inscription student);
        Student AuthentificateStudent(string email,string password);
        Student FindStudentByEmail(string email);
        Student FindStudentProfile(string id);


    }
}