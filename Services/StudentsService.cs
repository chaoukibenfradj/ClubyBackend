

using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using clubyApi.Repositories;

namespace clubyApi.Services
{
    public class StudentService :IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo){
            _repo=repo;

        }

        public Student AuthentificateStudent(string email, string password)=> _repo.AuthentificateStudent(email,password);
        

        public Student CreateStudent(Student student)=>_repo.CreateStudent(student);
    }

    public interface IStudentService
    {
        Student AuthentificateStudent(string email,string password);
        Student CreateStudent(Student student)

    }
}