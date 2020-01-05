using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
namespace clubyApi.Models
{
    public class PartModel
    {

        public string eventId { get; set; }

        public string userId { get; set; }



        public PartModel(string eId, string uId)
        {

            this.eventId = eId;
            this.userId = uId;


        }
        public PartModel() { }




    }
}