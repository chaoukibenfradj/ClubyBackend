using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Club
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name{ get;set;}
        [BsonElement("Description")]
        public string Description{ get;set;}
        [BsonElement("Email")]
        public string Email{ get ; set;}
        [BsonElement("Password")]
        public string Password{ get ; set;}
        [BsonElement("Photo")]
        public string Photo{ get;set;}
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Institut")]
        public string Institut{ get ; set;}
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Domain")]
        public string Domain{ get ; set;}
         [BsonElement("CreationDate")]
        public string CreationDate{ get ; set;}
        





    }
}