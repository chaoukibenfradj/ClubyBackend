using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Institut
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name{ get;set;}
        [BsonElement("Region")]
        public string Region{ get;set;}
        
        





    }
}