using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IStudentService
    {
        Student FindStudentProfile(string id);
        Student CreateStudent(User user,Institute institute);
        UpdateResult UpdateStudentProfile(UpdateDto update);
        Student FindStudent(string id);



    }
}