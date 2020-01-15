using clubyApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ClubyBackend.Models
{
    public class Email
    {
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id {get;set;}
     
        [BsonElement("Subject")]
        public string Subject  {get;set;}
        [BsonElement("Content")]
        public string Content  {get;set;}

        [BsonElement("SendDate")]
        public string SendDate  {get;set;}

        [BsonElement("Sender")]
        public User Sender{get;set;}

        [BsonElement("Receiver")]
        public User Receiver{get;set;}
          public Email(){

        }
        
        public Email(EmailDto email,User sender,User receiver){
            Subject=email.Subject;
            Content=email.Content;
            SendDate=email.SendDate;
          
            Sender= new User(sender.Id);
            Receiver=new User(receiver.Id);


        }
       
    }

}