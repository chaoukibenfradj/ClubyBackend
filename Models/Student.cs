using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Student
    {
       
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        
        [BsonElement("FirstName")]

        public string FirstName{ get;set;}
        
        [BsonElement("LastName")]

        public string LastName{ get;set;}
        
        [BsonElement("Email")]

        public string Email{ get ; set;}
        
        [BsonElement("Password")]

        public string Password{ get ; set;}
        
        [BsonElement("Institute")]
         public MongoDBRef Institute{ get ; set;}
        
        [BsonElement("Photo")]

        public string Photo{ get;set;}
      
        [BsonElement("EventInscription")]

        public string EventInscription{ get ; set;}

    }
}