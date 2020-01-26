using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

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
        
        [Required (ErrorMessage = "Domain name is required")]
        [BsonElement("Name")]

        public string Name{ get;set;}
    }
}