using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
         [BsonElement("Name")]
        public string Name{ get;set;}
        [BsonElement("Description")]
        public string Description{ get;set;}
      
        [BsonElement("Photo")]
        public string Photo{ get;set;}
        [BsonElement("Institut")]
        public Institute Institute{ get ; set;}
        [BsonElement("Domain")]
        public Domain Domain{ get ; set;}
         [BsonElement("CreationDate")]
        public string CreationDate{ get ; set;}
        [BsonElement("User")]
        public User User{get;set;}
        
        
    }
}