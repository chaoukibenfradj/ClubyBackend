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
    public class ClubRepository:IClubRepository
    {
        private readonly IMongoCollection<Club> _clubs;
        
        public ClubRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clubs = database.GetCollection<Club>(settings.ClubCollectionName); 

        }

       
        public  Club FindClubProfile(string id){
            return _clubs.Find<Club>(Club=> Club.Id==id).FirstOrDefault();
        }
        public Club FindClubByEmail(string email) => _clubs.Find<Club>(stud => stud.Email == email).FirstOrDefault();

        public UpdateResult CompleteClubInscription(string id,string institute, string photo)
        {
            var filter = Builders<Club>.Filter.Eq("id",id);
            Console.Write(institute);

            var update=Builders<Club>.Update.Set("Photo", photo).Set("Institute", institute);

            return _clubs.UpdateOne(filter,update);
        }
    }

    
}