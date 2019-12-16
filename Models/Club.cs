using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Club

    {

        public Club(User user)
        {
            User=new MongoDBRef("User",user.Id);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Description")]
        public string Description{ get;set;}
      
        [BsonElement("Photo")]
        public string Photo{ get;set;}
        [BsonElement("Institut")]
        public string Institut{ get ; set;}
        [BsonElement("Domain")]
        public string Domain{ get ; set;}
         [BsonElement("CreationDate")]
        public string CreationDate{ get ; set;}
        [BsonElement("User")]
        public MongoDBRef User{get;set;}
        
        
    }
}