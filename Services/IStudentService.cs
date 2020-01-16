using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IStudentService
    {
        Student FindStudentProfile(string id);
        Student CreateStudent(User user,Institute institute);
        Student UpdateStudentProfile(string id, string photo, string institute);
        Student FindStudent(string id);



    }
}