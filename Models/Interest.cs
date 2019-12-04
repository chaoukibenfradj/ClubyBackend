using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Interest
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public  string Id{ get;set;}
        
        [BsonElement("InterestName")]

        public string InterestName{ get;set;}
    }
}