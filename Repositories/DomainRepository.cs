

using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public class DomainRepository : IDomainRepository
    {
        private readonly IMongoCollection<Domain> _domains;
        
        public DomainRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _domains = database.GetCollection<Domain>(settings.DomainCollectionName); 

        }

        public Domain CreateDomain(Domain domain)
        {
            _domains.InsertOne(domain);
            return domain;
        }

        public Domain DeleteDomain(string id)
        {
            return _domains.FindOneAndDelete(d=>d.Id==id);
        }
        public  List<Domain> getDomains(){
            return _domains.Find(Builders<Domain>.Filter.Empty).ToList();
        }

        public UpdateResult ModifyDomain(Domain domain)
        {
            var filter=Builders<Domain>.Filter.Eq(d=>d.Id,domain.Id);

            var update=Builders<Domain>.Update.Set("Name",domain.Name);
            return _domains.UpdateOne(filter,update);
        }
    }
}