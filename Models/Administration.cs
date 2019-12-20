using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Administration
    {
        private User user;

        public Administration(Administration admin)
        {
            Institute=admin.Institute;
            User =new MongoDBRef("User",admin.Id);
        }
         public Administration(string institute,string id )
        {
            Institute=institute;
            User =new MongoDBRef("User",id);
        }
        public Administration(string institute )
        {
            Institute=institute;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Institute")]
        public string Institute{get;set;}
        [BsonElement("User")]
        public MongoDBRef User{get;set;}

    }
}