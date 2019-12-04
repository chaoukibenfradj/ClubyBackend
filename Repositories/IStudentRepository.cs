using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IStudentRepository
    {
        Student FindStudentProfile(string id);
        Student CreateStudent(User user);


    }
}