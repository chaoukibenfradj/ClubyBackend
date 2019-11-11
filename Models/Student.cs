using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("FirstName")]
        public string FirstName{ get;set;}
        [BsonElement("LasttName")]
        public string LastName{ get;set;}
        [BsonElement("Email")]
        public string Email{ get ; set;}
        [BsonElement("Password")]
        public string Password{ get ; set;}
        [BsonElement("Photo")]
        public string Photo{ get;set;}
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Institut")]
        public string Institut{ get ; set;}
        [BsonElement("Inscription")]
        public string Inscription{ get ; set;}
        





    }
}