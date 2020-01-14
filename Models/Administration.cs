using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace clubyApi.Models
{
    public class Administration
    {
        private User user;

        public Administration(Administration admin)
        {
            Institute=admin.Institute;
            User =new User(admin.Id);
        }
         public Administration(string institute,User user )
        {
            Institute=new Institute(institute);
            User =new User(user.Id);
        }
        public Administration(string institute )
        {
            
            Institute=new Institute(institute);
        }
          public Administration( )
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Institute")]
        public Institute Institute{get;set;}
        [BsonElement("User")]
        public User User{get;set;}

    }
}