using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities.Core;
namespace clubyApi.Models
{
    public class User 
    {
         public User(){}
         public User(string id){
             Id=id;
         }
        public User(User user)
        {
          
           FirstName=user.FirstName;
           LastName=user.LastName;
           Email=user.Email;
           Password=user.Password;
           Role=user.Role;
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
        [BsonElement("Password")]
        [Required (ErrorMessage = "Password is required")]

        public string Password{ get ; set;}
        [Required (ErrorMessage = "Role is required")]
        [BsonElement("Role")]
        public string Role{ get ; set;}
        [BsonIgnore]
        public string Token{ get ; set;}
       
    }
}