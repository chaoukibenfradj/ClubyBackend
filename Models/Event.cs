using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using ClubyBackend.Models;

namespace clubyApi.Models
{
   public class Event
    {
          
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
        [Required (ErrorMessage = "Event name is required")]
        [BsonElement("Name")]
        public string Name  {get;set;}
        [Required (ErrorMessage = "Starting date is required")]
        [BsonElement("BeginDate")]
        public string BeginDate  {get;set;}
        [Required (ErrorMessage = "Finishing date is required")]
        
        [BsonElement("EndDate")]
        public string EndDate  {get;set;}
        [BsonElement("price")]
        public string price  {get;set;}
        [BsonElement("Photo")]
        [Required (ErrorMessage = "Event photo is required")]
        public string Photo  {get;set;}
        [BsonElement("Description")]
        [Required (ErrorMessage = "Event description is required")]
        [MaxLength(300) ]
        public string Description  {get;set;}     
        [BsonElement("Location")]
        [Required (ErrorMessage = "Event location is required")]
        public string Location {get;set;}
        [BsonElement("CreationDate")]
        public string CreationDate {get;set;}
        [BsonElement("Domain")]
        public Domain Domain {get;set;}

        [BsonElement("Club")]
        public Club Club {get;set;}

        [BsonElement("Institute")]
        public Institute Institute {get;set;}

        

        [BsonElement("Number")]
        public int NumberParticipation { get; set; }

        public Event(Event e){

            this.Name=e.Name;
            this.price=e.price;
            this.Location=e.Location;
            this.Photo=e.Photo;
            this.Domain=e.Domain;
            this.Description=e.Description;
            this.BeginDate=e.BeginDate;
            this.EndDate=e.EndDate;
            this.Institute=e.Institute;
            this.Club=e.Club;
            this.NumberParticipation=e.NumberParticipation;


        }
         public Event(EventDto e){

            this.Name=e.Name;
            this.price=e.price;
            this.Location=e.Location;
            this.Photo=e.Photo;
            this.Domain=new Domain(e.Domain);
            this.Description=e.Description;
            this.BeginDate=e.BeginDate;
            this.EndDate=e.EndDate;
            this.Institute=new Institute(e.Institute);
            this.Club=new Club(e.Club);
            this.NumberParticipation=e.NumberParticipation;

          

        }
        public Event(){}
        public Event(string id){
            Id=id;
        }

        
    }
}