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
        public Student(User user,Institute institute)
        {
            this.user=new User(user.Id);
            this.Institute=new Institute(institute.Id);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        
        
        [BsonElement("Institute")]
        public Institute Institute{ get ; set;}
        
        [BsonElement("Photo")]

        public string Photo{ get;set;}
      
        [BsonElement("EventInscription")]

        public string EventInscription{ get ; set;}

        [BsonElement("User")]
        public User user{get;set;}

    }
}