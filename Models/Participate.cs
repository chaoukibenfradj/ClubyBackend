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

        public User user { get; set; }

        public string DateParticipate { get; set; }



        public Participate(User pUserId,string pDateParticipate)
        {

            this.user = pUserId;
            this.DateParticipate = pDateParticipate;


        }
        public Participate(Participate p)
        {

            this.user = p.user;
            this.DateParticipate = p.DateParticipate;


        }
        public Participate() { }




    }
}