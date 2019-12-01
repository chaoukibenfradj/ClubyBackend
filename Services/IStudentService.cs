using clubyApi.Models;

namespace clubyApi.Services
{
     public interface IStudentService
    {
        Student AuthentificateStudent(string email,string password);
        Inscription CreateStudent(Inscription student);

    }
}