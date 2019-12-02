using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Student
    {
        public Student(Inscription inscription)
        {
            Email = inscription.Email;
            Password = inscription.Password;
            FirstName = inscription.FirstName;
            LastName = inscription.LastName;
        }
        
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        public string FirstName{ get;set;}
        public string LastName{ get;set;}
        
        [BsonElement("Email")]

        public string Email{ get ; set;}
        
        [BsonElement("Password")]

        public string Password{ get ; set;}
        
        [BsonElement("Institute")]
         public string Institute{ get ; set;}
        
        [BsonElement("Photo")]

        public string Photo{ get;set;}
      
        [BsonElement("EventInscription")]

        public string EventInscription{ get ; set;}
        public string Token{ get ; set;}

    }
}