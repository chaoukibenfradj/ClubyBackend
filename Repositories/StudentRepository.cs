using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
namespace clubyApi.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;
        
        public StudentRepository(IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCollectionName); 

        }

        public Student AuthentificateStudent(string email, string password)
        {
            Student result=null;
            Student student=FindStudentByEmail(email);
            if(student!=null){
                 HashPassword hashPassword=new HashPassword();
                if(student.Password == hashPassword.HashedPass(password)){
                    result=student;
                }

            }
            return result;
        }

        public Inscription CreateStudent(Inscription student)
        {   
            Inscription result=null;
            if(FindStudentByEmail(student.Email)==null){
                result=student;
                var hashPassword=new HashPassword();
                student.Password=hashPassword.HashedPass(student.Password);
                _students.InsertOne(new Student(student.Email,student.Password,student.FirstName,student.LastName));
            }
            return result;
        }
        public  Student FindStudentProfile(string id){
            Console.Write(id);
            return _students.Find<Student>(Student=> Student.Id==id).FirstOrDefault();
        }
        public Student FindStudentByEmail(string email) => _students.Find<Student>(stud => stud.Email == email).FirstOrDefault();

        
    }

    
}