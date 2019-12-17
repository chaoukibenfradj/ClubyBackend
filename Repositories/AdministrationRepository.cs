using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly IMongoCollection<Administration> _admins;
        
        public AdministrationRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _admins = database.GetCollection<Administration>(settings.AdministrationCollectionName); 

        }
        public Administration CreateAdmin(Administration administration)
        {
            throw new System.NotImplementedException();
        }

        public Administration DeleteAdmin(string id)
        {
            throw new System.NotImplementedException();
        }

        public Administration ModifyAdmin(string id, Administration administration)
        {
            throw new System.NotImplementedException();
        }
    }
}