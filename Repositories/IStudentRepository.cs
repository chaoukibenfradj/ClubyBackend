using clubyApi.Models;
using ClubyBackend.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IStudentRepository
    {
        Student FindStudentProfile(string id);
        Student FindStudent(string id);

        Student CreateStudent(User user,Institute institute);
        UpdateResult UpdateStudentProfile(UpdateDto update);


    }
}