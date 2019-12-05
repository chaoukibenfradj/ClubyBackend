using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
     public interface IInstituteService
    {
       public Institute CreateInstitute(Institute institute);
       public List<Institute> FindInstituteByDomain(string domain);
       public Institute FindInstituteByName(string name);

       public List<Institute> FindInstituteByRegion(string region);
        public List<Institute> FindAllInstitutes();
       

    }
}