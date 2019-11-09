

using clubyApi.Models;
using MongoDB.Driver;

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
            _students.InsertOne(student);
            return student;
        }

    }
}