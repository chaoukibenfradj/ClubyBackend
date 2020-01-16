using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Services
{
    public interface IDomainService
    {
         Domain CreateDomain(Domain domain);
         UpdateResult ModifyDomain(Domain domain);
         Domain DeleteDomain(string id);
        List<Domain> getDomains();

        
    }
}