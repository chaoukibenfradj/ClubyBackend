using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Administration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Institute")]
        public string Institute{get;set;}
        [BsonElement("User")]
        public MongoDBRef User{get;set;}

    }
}