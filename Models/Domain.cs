namespace clubyApi.Models
{
    public class Domain
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public  string Id{ get;set;}
        
        [BsonElement("DomainName")]

        public string DomainName{ get;set;}
    }
}