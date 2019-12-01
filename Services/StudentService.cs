

using clubyApi.Models;

using clubyApi.Repositories;

namespace clubyApi.Services
{
    public class StudentService :IStudentService
    {
        private  readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo=repo ;

        }

        public Student AuthentificateStudent(string email, string password)
        {
            return _repo.AuthentificateStudent(email,password);
        }

        public Inscription CreateStudent(Inscription student)
        {
           return _repo.CreateStudent(student);
    
        }
        public  Student FindStudentProfile(string id){
            return _repo.FindStudentProfile(id);
        }

    }

   
}