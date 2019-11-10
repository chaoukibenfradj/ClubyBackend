

using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;

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
        public Student Create(Student student){
            var hashPassword=new HashPassword();
            student.Password=hashPassword.HashedPass(student.Password);
            _students.InsertOne(student);
            return student;
        }

    }
}