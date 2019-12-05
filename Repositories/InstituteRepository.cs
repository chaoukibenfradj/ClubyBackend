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
    }

    
}