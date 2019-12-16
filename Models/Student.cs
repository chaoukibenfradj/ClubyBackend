using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Student
    {

        public Student(User user)
        {
            User=new MongoDBRef("User",user.Id);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        
        
        [BsonElement("Institute")]
         //public MongoDBRef Institute{ get ; set;}
         public string Institute{ get ; set;}
        
        [BsonElement("Photo")]

        public string Photo{ get;set;}
      
        [BsonElement("EventInscription")]

        public string EventInscription{ get ; set;}

        [BsonElement("User")]
        public MongoDBRef User{get;set;}

    }
}