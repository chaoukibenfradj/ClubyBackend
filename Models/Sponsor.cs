using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Sponsor

    {
        public Sponsor(User user){
            User=new MongoDBRef("User",user.Id);
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        
        
        [BsonElement("Entreprise")]
         public MongoDBRef Entreprise{ get ; set;}
        
        [BsonElement("Photo")]
        public string Photo{ get;set;}

        [BsonElement("Interests")]
        public List<MongoDBRef> Interests{ get;set;}
      

        [BsonElement("User")]
        public MongoDBRef User{get;set;}
    }
}