using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class Institute
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        [Required (ErrorMessage = "Institute name is required")]

        public string Name{ get;set;}
        [BsonElement("Region")]
        [Required (ErrorMessage = "Institute region is required")]

        public string Region{ get;set;}

        [BsonElement("Domain")]
        [Required (ErrorMessage = "Institute domain is required")]

        public string Domain{ get;set;}
        
        





    }
}