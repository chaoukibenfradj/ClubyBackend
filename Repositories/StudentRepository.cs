using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
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
            throw new System.NotImplementedException();
        }

        public Student CreateStudent(Student student)
        {   
            Student result=null;
            if(FindStudentByEmail(student.Email)==null){
                result=student;
                var hashPassword=new HashPassword();
                student.Password=hashPassword.HashedPass(student.Password);
                _students.InsertOne(student);
            }
            return result;

        }
        public Student FindStudentByEmail(string email) => _students.Find<Student>(stud => stud.Email == email).FirstOrDefault();
    }

    public interface IStudentRepository
    {
        Student CreateStudent(Student student);
        Student AuthentificateStudent(string email,string password);
        Student FindStudentByEmail(string email);

    }
}