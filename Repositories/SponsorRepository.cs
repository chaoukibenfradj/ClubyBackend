using System;
using System.Collections.Generic;
using System.Linq;
using clubyApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace clubyApi
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly IMongoCollection<Sponsor> _sponsors;
        private readonly IMongoCollection<User> _users;


        public SponsorRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _sponsors = database.GetCollection<Sponsor>(settings.SponsorCollectionName); 
             _users = database.GetCollection<User>(settings.UserCollectionName); 


        }
        public Sponsor CreateSponsor(User user)
        {
             Sponsor resultat=new Sponsor(user);
             _sponsors.InsertOne(resultat);
             return resultat;
        }

        public Sponsor FindSponsor(string id)
        {
           Sponsor resultat=null;
              
                 var query=from s in _sponsors.AsQueryable().Where(Sponsor=> Sponsor.User.Id==id) 
                    join u in _users.AsQueryable() on s.User.Id equals u.Id
                    select 
                    new Sponsor(){
                        Id=s.Id,
                        Entreprise=s.Entreprise,
                        Interests=s.Interests,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            
           
           
            
            return resultat;
        }

        public List<Sponsor> ShowAllSponsors()
        {
           
            return _sponsors.Find<Sponsor>(new FilterDefinitionBuilder<Sponsor>().Empty).ToList<Sponsor>();
        }
       

        Sponsor ISponsorRepository.FindSponsorProfile(string id)
        {
            Sponsor resultat=null;
              
                 var query=from s in _sponsors.AsQueryable().Where(Sponsor=> Sponsor.Id==id) 
                    join u in _users.AsQueryable() on s.User.Id equals u.Id
                    select 
                    new Sponsor(){
                        Id=s.Id,
                        Entreprise=s.Entreprise,
                        Interests=s.Interests,
                        User=u
                    };
                    resultat=query.FirstOrDefault();
            
           
           
            
            return resultat;
        }
       
    }
}