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

        public string Name{ get;set;}
        [BsonElement("Region")]

        public string Region{ get;set;}
        public string Photo{get;set;}

        [BsonElement("Domain")]

        public string Domain{ get;set;}
        
        





    }
}