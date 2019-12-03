using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using clubyApi.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace clubyApi.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;
        private readonly AppSettings _appsettings;
        
        public StudentRepository(IOptions<AppSettings> appSettings, IClubyDatabaseSettings settings){
            _appsettings=appSettings.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCollectionName); 

        }

        public Student CreateStudent(User user)
        {     Student resultat=new Student(user);
             _students.InsertOne(resultat);
             return resultat;
            
        }

        public  Student FindStudentProfile(string id){
            return _students.Find<Student>(Student=> Student.Id==id).FirstOrDefault();
        }

        
    }

    
}