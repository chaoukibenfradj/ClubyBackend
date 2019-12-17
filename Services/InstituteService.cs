using clubyApi.Models;
using MongoDB.Driver;
using clubyApi.Utils;
using System;
using System.Linq;
namespace clubyApi.Services
{using System.Collections.Generic;
using clubyApi.Repositories;
using MongoDB.Driver;

    public class InstituteService :IInstituteService
    {
        private  readonly IInstituteRepository _repo;
        public InstituteService(IInstituteRepository repo)
        {
            _repo=repo ;

        }

        public Institute CreateInstitute(Institute institute)
        {
            return _repo.CreateInstitute(institute);
        }

        public List<Institute> FindAllInstitutes()
        {
           return _repo.FindAllInstitutes();
        }

        public List<Institute> FindInstituteByDomain(string domain)
        {
            return _repo.FindInstituteByDomain(domain);
        }

        public Institute FindInstituteByName(string name)
        {
            return _repo.FindInstituteByName(name);
        }

        public List<Institute> FindInstituteByRegion(string region)
        {
            return _repo.FindInstituteByRegion(region);
        }

        public Institute ModifyInstitute(string id,Institute institute)
        {
            return _repo.ModifyInstitute(id,institute);
        }
    }
    
}