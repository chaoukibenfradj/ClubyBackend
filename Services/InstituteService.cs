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

       public UpdateResult CompleteInstitutInscription(string id, string institute, string photo)
        {
            return _repo.CompleteInstitutInscription(id,institute,photo);
        }

       public  Institut FindInstitutProfile(string id){
            return _repo.FindInstitutProfile(id);
        }
      
    


   

        
       

        


    }
    
}