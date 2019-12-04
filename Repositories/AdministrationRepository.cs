using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public class AdministrationRepository:IAdministrationRepository
    {
        private readonly IMongoCollection<Administration> _administrations;

        public AdministrationRepository(ClubyDatabaseSettings settings){
             var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _administrations = database.GetCollection<Administration>(settings.AdministrationCollectionName); 


        }

        public Administration createAdministration(Administration user)
        {
            Administration administration=new Administration(user);
            _administrations.InsertOne(administration);
            return administration;

        }


        
    }
}