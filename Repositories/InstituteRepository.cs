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
using System.Collections.Generic;
using MongoDB.Bson;

namespace clubyApi.Repositories
{
    public class InstituteRepository:IInstituteRepository
    {
        private readonly IMongoCollection<Institute> _instituts;
        
        public InstituteRepository( IClubyDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _instituts = database.GetCollection<Institute>(settings.InstituteCollectionName); 

        }

        public Institute CreateInstitute(Institute institute)
        {   
            Institute res=null;
            Institute institute1=FindInstituteByName(institute.Name);
            if(institute1==null){
                _instituts.InsertOne(institute);
                res=institute;

            }
            return res;
        }

        public List<Institute> FindAllInstitutes()
        {
            int limit=10;
            return _instituts.Find<Institute>(new FilterDefinitionBuilder<Institute>().Empty).Limit(limit).ToList<Institute>();
        }

        public List<Institute> FindInstituteByDomain(string domain)
        {
            return _instituts.Find<Institute>(i => i.Domain == domain).ToList<Institute>();

        }

        public Institute FindInstituteByName(string name)
        {
            return _instituts.Find<Institute>(i => i.Name == name).FirstOrDefault();

        }

        public List<Institute> FindInstituteByRegion(string region)
        {
            return _instituts.Find<Institute>(i => i.Region == region).ToList<Institute>();

        }

        public Institute ModifyInstitute(string id,Institute institute)
        {
            var filter=Builders<Institute>.Filter.Eq(s=>s.Id,id);

           if(institute.Domain!=null){
                Console.WriteLine(id);
                 var update=Builders<Institute>.Update.Set(s=>s.Domain,institute.Domain);
                 return _instituts.FindOneAndUpdate(filter,update);


            }
            
             if(institute.Photo!=null){
                var update=Builders<Institute>.Update.Set("Photo",institute.Photo);
                return _instituts.FindOneAndUpdate(filter,update);


            }
            
             if(institute.Name!=null){
                 Console.Write(institute.Name);
                 Console.Write(id);
                 var update=Builders<Institute>.Update.Set("Name",institute.Name);
                return _instituts.FindOneAndUpdate(filter,update);


            }
            
             if(institute.Region!=null){
                var update=Builders<Institute>.Update.Set("Region",institute.Region);
                return _instituts.FindOneAndUpdate(filter,update);


            }
            
            if(institute.Name!=null && institute.Domain!=null && institute.Region!=null && institute.Photo!=null){
                var update=Builders<Institute>.Update.Set("Name",institute.Name)
                .Set("Domain",institute.Domain)
                .Set("Region",institute.Region)
                .Set("Photo",institute.Photo);
                return _instituts.FindOneAndUpdate(filter,update);


            }
            return null;
        }
    }

    
}