

using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
namespace clubyApi.Services
{
    public class StudentsService
    {
        private readonly IMongoCollection<Student> _students;
        public StudentsService(IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCollectionName); 

        }
        public string Create(Student student){
            string result="email is already in use";
            var hashPassword=new HashPassword();
            long num = _students.Find<Student>(stud => stud.Email==student.Email).CountDocuments();
            if(num==0){
                result="account created with success";
                student.Password=hashPassword.HashedPass(student.Password);
                _students.InsertOne(student);
            }
            return result;
        }
        public Student Login(string email,string password){
            
            Student student = _students.Find<Student>(student => student.Email == email).FirstOrDefault();
            if(student!=null){
            
                HashPassword hashPassword=new HashPassword();
                if(student.Password != hashPassword.HashedPass(password)){
                    student=null;
                }
                
            }
            return student;
        } 

        public Student GetProfile(string id){
            Student student = _students.Find<Student>(student => student.Id == id).FirstOrDefault();
            return student;
        }

    }
}