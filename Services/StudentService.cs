

using clubyApi.Models;

using clubyApi.Repositories;
using MongoDB.Driver;

namespace clubyApi.Services
{
    public class StudentService :IStudentService
    {
        private  readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo=repo ;

        }

       

        public Student CreateStudent(User user,Institute institute)
        {
            return _repo.CreateStudent(user,institute);
        }
        public Student FindStudent(string id){
            return _repo.FindStudent(id);
        }
       
        public  Student FindStudentProfile(string id){
            return _repo.FindStudentProfile(id);
        }

        public Student UpdateStudentProfile(string id, string photo, string institute)
        {
            return _repo.UpdateStudentProfile(id,photo,institute);
        }
    }

   
}