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
            _admins.InsertOne(administration);
            return administration;
        }

        public Administration DeleteAdmin(string id)
        {
            return _admins.FindOneAndDelete(Admini=>Admini.Id==id);
        }

        public Administration ModifyAdmin(string id, string institute)
        {
              var filter=Builders<Administration>.Filter.Eq(s=>s.Id,id);

            var update=Builders<Administration>.Update.Set(s=>s.Institute,institute);
            return _admins.FindOneAndUpdate(filter,update);


            
        }
    }
}