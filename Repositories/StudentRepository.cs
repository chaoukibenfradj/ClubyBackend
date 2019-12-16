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
using MongoDB.Bson;

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

        public Student UpdateStudentProfile(string id, string photo, string institute)
        {
            var filter=Builders<Student>.Filter.Eq(s => s.User.Id,id);
            var update=Builders<Student>.Update.Set("Institute",(BsonString)institute).Set("Photo",(BsonString)photo);
            return   _students.FindOneAndUpdate<Student>(filter,update);
        }
    }

    
}