

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

      

        public Student CreateStudent(User user)
        {
            return _repo.CreateStudent(user);
        }

       
        public  Student FindStudentProfile(string id){
            return _repo.FindStudentProfile(id);
        }

    }

   
}