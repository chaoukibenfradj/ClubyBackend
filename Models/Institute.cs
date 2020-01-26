using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Institute
    {
        public Institute(){

        }
        public Institute(string Id){
            this.Id=Id;
            
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required (ErrorMessage = "Institut name is required")]
        [BsonElement("Name")]
        public string Name{ get;set;}

        [Required (ErrorMessage = "Institut Region is required")]
        [BsonElement("Region")]
        public string Region{ get;set;}

        public string Photo{get;set;}

        [BsonElement("Domain")]

        public string Domain{ get;set;}
        
        





    }
}