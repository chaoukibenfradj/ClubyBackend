using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IStudentRepository
    {
        Student FindStudentProfile(string id);
        Student CreateStudent(User user,Institute institute);
        Student UpdateStudentProfile(string id,string photo,string institute);


    }
}