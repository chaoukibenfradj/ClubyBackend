using System;
using clubyApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ClubyBackend.Models
{
    public class Email
    {
        public Email(){

        }
        public Email(Email email,User sender,User receiver){
            Subject=email.Subject;
            Content=email.Content;
            SendDate=email.SendDate;
          
            Sender= new MongoDBRef("User",sender.Id);
            Receiver= new MongoDBRef("User",receiver.Id);


        }
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
        public MongoDBRef Sender{get;set;}

        [BsonElement("Receiver")]
        public MongoDBRef Receiver{get;set;}
        
    }

}