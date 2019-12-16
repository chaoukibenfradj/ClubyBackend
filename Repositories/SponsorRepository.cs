using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly IMongoCollection<Sponsor> _sponsors;

        public SponsorRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _sponsors = database.GetCollection<Sponsor>(settings.SponsorCollectionName); 

        }
        public Sponsor CreateSponsor(User user)
        {
             Sponsor resultat=new Sponsor(user);
             _sponsors.InsertOne(resultat);
             return resultat;
        }
    }
}