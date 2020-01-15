using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Entities;
using MongoDB.Entities.Core;
namespace clubyApi.Models
{
    public class Student 
    {
       
        public Student(){

        }
        public Student(string student){
            Id=student;
        }
        public Student(User user,Institute institute)
        {
            this.user=new User(user.Id);
            this.Institute=new Institute(institute.Id);
        }
         public Student(Student student,User user)
        {
            this.user=user;
            this.Photo=student.Photo;
            
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        
        
        [BsonElement("Institute")]
        public Institute Institute{ get ; set;}
        
        [BsonElement("Photo")]

        public string Photo{ get;set;}
      

        [BsonElement("User")]
        public User user{get;set;}

    }
}