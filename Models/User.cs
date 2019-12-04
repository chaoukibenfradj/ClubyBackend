using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clubyApi.Models
{
    public class User
    {
        private User _user;
        public User(){}
        public User(User user)
        {
          
            _user=user;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public  string Id{ get;set;}
        
        [BsonElement("FirstName")]

        [Required (ErrorMessage = "Firstname is required")]

        public string FirstName{ get;set;}
        [Required (ErrorMessage = "Lastname is required")]
        
        [BsonElement("LastName")]

        public string LastName{ get;set;}
        
        [BsonElement("Email")]

        
        [Required (ErrorMessage = "Email is required")]
        
        [DataType(DataType.EmailAddress)]
        public string Email{ get;set;}
        [Required (ErrorMessage = "Password is required")]
        
        [BsonElement("Password")]

        public string Password{ get ; set;}

        [Required (ErrorMessage = "Role is required")]

        [BsonElement("Role")]

        public string Role{ get ; set;}
        [BsonIgnore]
        public string Token{ get ; set;}
    }
}