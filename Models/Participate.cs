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

        public string UserId { get; set; }

        public string DateParticipate { get; set; }



        public Participate(string pUserId,string pDateParticipate)
        {

            this.UserId = pUserId;
            this.DateParticipate = pDateParticipate;


        }
        public Participate(Participate p)
        {

            this.UserId = p.UserId;
            this.DateParticipate = p.DateParticipate;


        }
        public Participate() { }




    }
}