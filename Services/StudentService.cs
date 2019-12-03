

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

        public Student AuthentificateStudent(Authentification authentification)
        {
            return _repo.AuthentificateStudent(authentification);
        }

        public UpdateResult CompleteStudentInscription(string id, string institute, string photo)
        {
            return _repo.CompleteStudentInscription(id,institute,photo);
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