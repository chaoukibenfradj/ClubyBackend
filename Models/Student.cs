using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Student
    {
        public Student(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
        
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        public string FirstName{ get;set;}
        public string LastName{ get;set;}
        
        

        public string Email{ get ; set;}
        public string Password{ get ; set;}
        
        [BsonElement("Institute")]
         public string Institute{ get ; set;}
        
        [BsonElement("Photo")]

        public string Photo{ get;set;}
      

        public string Inscription{ get ; set;}
       

    }
}