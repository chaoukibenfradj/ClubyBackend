using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class EventModel
    { 
       
        [Required (ErrorMessage = "Event name is required")]

        public string Name  {get;set;}

        [Required (ErrorMessage = "Starting date is required")]

        public DateTime BeginDate  {get;set;}
        
        [Required (ErrorMessage = "Finishing date is required")]

        public DateTime EndDate  {get;set;}
                
        public float price  {get;set;}

        [Required (ErrorMessage = "Event description is required")]
        [MaxLength(300) ]

        public string Description  {get;set;}
        
        [Required (ErrorMessage = "Event location is required")]

        public string Location {get;set;}
        
        [Required (ErrorMessage = "Event domain is required")]

        public MongoDBRef Domain {get;set;}
        public MongoDBRef Institute { get; internal set; }
        public MongoDBRef Club { get; internal set; }


        public EventModel(){
            this.price=0;
        }
                
    }
}