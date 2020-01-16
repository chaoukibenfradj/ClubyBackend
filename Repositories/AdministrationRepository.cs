using System.Linq;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly IMongoCollection<Administration> _admins;
         private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Institute> _institutes;

        
        public AdministrationRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _admins = database.GetCollection<Administration>(settings.AdministrationCollectionName); 
            _users = database.GetCollection<User>(settings.UserCollectionName); 
             _institutes = database.GetCollection<Institute>(settings.InstituteCollectionName); 

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

            var update=Builders<Administration>.Update.Set(s=>s.Institute.Id,institute);
            return _admins.FindOneAndUpdate(filter,update);


            
        }

        Administration IAdministrationRepository.FindAdminProfile(string id)
        {
             Administration resultat=null;
                    if(_admins.AsQueryable().Where(admin=> admin.Id==id).FirstOrDefault().Institute.Id==null){
                    var query=from admin in _admins.AsQueryable().Where(admin=> admin.Id==id) 
                    join u in _users.AsQueryable() on admin.User.Id equals u.Id                
                    select 
                    new Administration(){
                        Id=admin.Id,
                        Institute=admin.Institute,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
           
            }
            else{
                    var query=from admin in _admins.AsQueryable().Where(admin=> admin.Id==id) 
                    join u in _users.AsQueryable() on admin.User.Id equals u.Id                
                    join inst in _institutes.AsQueryable() on admin.Institute.Id equals inst.Id 
                    select 
                    new Administration(){
                        Id=admin.Id,
                        Institute=inst,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
           
           
            
            return resultat;
        }
        public    Administration FindAdmin(string id){
              Administration resultat=null;
                    if(_admins.AsQueryable().Where(admin=> admin.User.Id==id).FirstOrDefault().Institute.Id==null){
                    var query=from admin in _admins.AsQueryable().Where(admin=> admin.User.Id==id) 
                    join u in _users.AsQueryable() on admin.User.Id equals u.Id                
                    select 
                    new Administration(){
                        Id=admin.Id,
                        Institute=admin.Institute,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
           
            }
            else{
                    var query=from admin in _admins.AsQueryable().Where(admin=> admin.User.Id==id) 
                    join u in _users.AsQueryable() on admin.User.Id equals u.Id                
                    join inst in _institutes.AsQueryable() on admin.Institute.Id equals inst.Id 
                    select 
                    new Administration(){
                        Id=admin.Id,
                        Institute=inst,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            }
           
           
            
            return resultat;

        }

    }
}