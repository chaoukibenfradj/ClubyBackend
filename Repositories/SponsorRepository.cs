using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public class SponsorRepository:ISponsorRepository
    {
        private readonly IMongoCollection<Sponsor> _sponsors;

        public SponsorRepository(ClubyDatabaseSettings settings){
             var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _sponsors = database.GetCollection<Sponsor>(settings.SponsorCollectionName); 


        }

        public Sponsor ChooseInterests(Interest interest)
        {
            throw new System.NotImplementedException();
        }
    }
}