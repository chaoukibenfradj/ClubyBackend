using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Club

    {
        
        public Club(){}
        public Club(string id){
            Id=id;
        }
        public Club(User user,Institute institute,Domain domain)
        {
            User=new User(user.Id);
            Institute =new Institute(institute.Id);
            Name=user.FirstName+user.LastName;
            Domain=new Domain(domain.Id);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required (ErrorMessage = "Club name is required")]
        [BsonElement("Name")]
        public string Name{ get;set;}
        [Required (ErrorMessage = "Club descrition is required")]
        [BsonElement("Description")]
        public string Description{ get;set;}
      
        [BsonElement("Photo")]
        public string Photo{ get;set;}
        [BsonElement("Institut")]
        public Institute Institute{ get ; set;}
        [BsonElement("Domain")]
        public Domain Domain{ get ; set;}
        [Required (ErrorMessage = "Club creation date is required")]
        [BsonElement("CreationDate")]
        public string CreationDate{ get ; set;}
        [BsonElement("User")]
        public User User{get;set;}
        
        
    }
}