using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Sponsor

    {
        public Sponsor(User user){
            User=new User(user.Id);
        }
        public Sponsor(){
            
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        
        
        [BsonElement("Entreprise")]
         public string Entreprise{ get ; set;}
        
        [BsonElement("Photo")]
        public string Photo{ get;set;}

        [BsonElement("Interests")]
        public List<string> Interests{ get;set;}
      

        [BsonElement("User")]
        public User User{get;set;}
    }
}