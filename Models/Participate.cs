using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
namespace clubyApi.Models
{

  public class Participate
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
         [BsonElement("Participant")]
        public Student user { get; set; }
         [BsonElement("Event")]
        
        public Event Event{get;set;}
        
        [BsonElement("Date")]

        public string DateParticipate { get; set; }
         [BsonElement("Accepted")]

        public Boolean Accepted { get; set; }



        public Participate(string pUserId ,string pDateParticipate )
        {

            this.user = new Student(pUserId);
            this.DateParticipate = pDateParticipate;


        }
        
        public Participate(Participate p)
        {

            this.Event=p.Event;
            this.user = p.user;
            this.DateParticipate = p.DateParticipate;
            this.Accepted=false;


        }
        public Participate() { }
         public Participate(string p,string e,string d)
        {

            this.Event=new Event(p);
            this.user = new Student(e);
            this.DateParticipate = d;
            this.Accepted=false;


        }
           public Participate(Student student,User user)
        {

          
            this.user = new Student(student,user);
           


        }




    }
}