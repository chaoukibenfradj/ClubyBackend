using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Domain
    {
        public Domain(){

        }
         public Domain(string domain){
            Id=domain;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public  string Id{ get;set;}
        
        [BsonElement("Name")]

        public string Name{ get;set;}
    }
}