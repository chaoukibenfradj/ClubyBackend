using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IInstituteRepository
    {
       
       public Institute CreateInstitute(Institute institute);
        public Institute ModifyInstitute(string id,Institute institute);

        public List<Institute> FindAllInstitutes();

       public List<Institute> FindInstituteByDomain(string domain);
       public Institute FindInstituteByName(string name);
       public List<Institute> FindInstituteByRegion(string region);


    }
}