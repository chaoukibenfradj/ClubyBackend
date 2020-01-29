using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using clubyApi.Helper;
using Microsoft.Extensions.Options;

using System.Linq;
using ClubyBackend.Models;

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
        
        //find student by student id 
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
       // find student by user id
        public Student FindStudent(string id){
             Student resultat=null;
                    if(_students.AsQueryable().Where(Student=> Student.user.Id==id).FirstOrDefault().Institute.Id==null){
                    var query=from s in _students.AsQueryable().Where(Student=> Student.user.Id==id) 
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
                 var query=from s in _students.AsQueryable().Where(Student=> Student.user.Id==id) 
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
      

          public UpdateResult UpdateStudentProfile(UpdateDto student)
          {
             UpdateResult result=null;
          
              var filter=Builders<Student>.Filter.Eq("Id",student.Id);
              if(student.Photo!=null && student.Institute!=null){
                var update=Builders<Student>.Update.Set("Photo",student.Photo).Set("Institute",new Institute(student.Institute));
                result=_students.UpdateOne(filter,update);
              }
               else if(student.Photo!=null){
                var update=Builders<Student>.Update.Set("Photo",student.Photo);
                result=_students.UpdateOne(filter,update);

              }
               else if(student.Institute!=null){
                var update=Builders<Student>.Update.Set("Institute",new Institute(student.Institute));
                result=_students.UpdateOne(filter,update);

              }
               else if(student.Photo!=null 
               && student.Institute!=null
                && student.LastName!=null 
                && student.FirstName!=null
                ){
                var update_1=Builders<Student>.Update.Set("Photo",student.Photo).Set("Institute",new Institute(student.Institute));
                var update_2=Builders<User>.Update.Set("LastName",student.LastName).Set("FirstName",student.FirstName);
                Student s=_students.Find(s=>s.Id==student.Id).FirstOrDefault();
                _users.UpdateOne(Builders<User>.Filter.Eq("Id",s.user.Id),update_2);
                result=_students.UpdateOne(filter,update_1);
              }
               else if(
                student.LastName!=null 
                && student.FirstName!=null){
                var update_2=Builders<User>.Update.Set("LastName",student.LastName).Set("FirstName",student.FirstName);
                Student s=_students.Find(s=>s.Id==student.Id).FirstOrDefault();
               result= _users.UpdateOne(Builders<User>.Filter.Eq("Id",s.user.Id),update_2);
               
              }
              
               return result;
            
          }
    }

    
}