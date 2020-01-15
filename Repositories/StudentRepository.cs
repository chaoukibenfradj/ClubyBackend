using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using clubyApi.Helper;
using Microsoft.Extensions.Options;

using System.Linq;

namespace clubyApi.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Institute> _institutes;


        private readonly AppSettings _appsettings;
        
        public StudentRepository(IOptions<AppSettings> appSettings, IClubyDatabaseSettings settings){
            _appsettings=appSettings.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCollectionName); 
            _users = database.GetCollection<User>(settings.UserCollectionName); 
            _institutes = database.GetCollection<Institute>(settings.InstituteCollectionName); 


        }

        public Student CreateStudent(User user,Institute institute)
        {     Student resultat=new Student(user,institute);
             _students.InsertOne(resultat);
             return resultat;
            
        }

        public  Student FindStudentProfile(string id){
            Student resultat=null;
                    if(_students.AsQueryable().Where(Student=> Student.Id==id).FirstOrDefault().Institute.Id==null){
                    var query=from s in _students.AsQueryable().Where(Student=> Student.Id==id) 
                    join u in _users.AsQueryable() on s.user.Id equals u.Id                
                    select 
                    new Student(){
                        Id=s.Id,
                        Institute=s.Institute,
                        Photo=s.Photo,
                        user=u
                    };
                    resultat=query.FirstOrDefault();
           
            }
            else{
                 var query=from s in _students.AsQueryable().Where(Student=> Student.Id==id) 
                    join u in _users.AsQueryable() on s.user.Id equals u.Id
                    join inst in _institutes.AsQueryable() on s.Institute.Id equals inst.Id 
                    select 
                    new Student(){
                        Id=s.Id,
                        Institute=inst,
                        Photo=s.Photo,
                        user=u
                    };
                    resultat=query.FirstOrDefault();
            }
           
           
            
            return resultat;
        }
      

          public Student UpdateStudentProfile(string id, string photo, string institute)
          {
             
          
              var filter=Builders<Student>.Filter.Eq("Id",id);
              var update=Builders<Student>.Update.Set("Photo",photo).Set("Institute",new Institute(institute));
              return _students.FindOneAndUpdate(filter,update);
            
          }
    }

    
}