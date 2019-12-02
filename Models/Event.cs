using System;

namespace clubyApi.Models
{
    public class Event
    {
        public string Id {get;set;}
        public string Name  {get;set;}
        public DateTime BeginDate  {get;set;}
        public DateTime EndDate  {get;set;}
        public float price  {get;set;}
        public string Description  {get;set;}

        public string Loaction {get;set;}
        public DateTime CreationDate {get;set;}


        
    }
}