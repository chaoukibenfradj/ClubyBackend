using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Event
    {
          
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
        [BsonElement("Name")]

        public string Name  {get;set;}
        
        [BsonElement("BeginDate")]

        public DateTime BeginDate  {get;set;}
        
        [BsonElement("EndDate")]

        public DateTime EndDate  {get;set;}
        
        [BsonElement("price")]

        public float price  {get;set;}

        [BsonElement("Description")]

        public string Description  {get;set;}
        
        [BsonElement("Location")]

        public string Location {get;set;}
        
        [BsonElement("CreationDate")]

        public DateTime CreationDate {get;set;}
        
        [BsonElement("Domain")]

        public MongoDBRef Domain {get;set;}
        
        [BsonElement("Club")]

        public MongoDBRef Club {get;set;}
        
        [BsonElement("Institute")]

        public MongoDBRef Institute {get;set;}


        
    }
}