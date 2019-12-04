using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using clubyApi.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace clubyApi.Repositories
{
    public class InstitutRepository:IInstitutRepository
    {
        private readonly IMongoCollection<Institut> _instituts;
        
        public InstitutRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _instituts = database.GetCollection<Institut>(settings.InstitutCollectionName); 

        }

       
        public  Institut FindInstitutProfile(string id){
            return _instituts.Find<Institut>(Institut=> Institut.Id==id).FirstOrDefault();
        }

        public UpdateResult CompleteInstitutInscription(string id,string name, string region)
        {
            var filter = Builders<Institut>.Filter.Eq("id",id);
            Console.Write(name);

            var update=Builders<Institut>.Update.Set("Name", name).Set("Region", region);

            return _instituts.UpdateOne(filter,update);
        }
    }

    
}