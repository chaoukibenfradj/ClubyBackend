using System.Collections.Generic;
using clubyApi.Models;
using MongoDB.Driver;

namespace clubyApi.Repositories
{
    public interface IDomainRepository
    {
         Domain CreateDomain(Domain domain);
        UpdateResult ModifyDomain(Domain domain);
         Domain DeleteDomain(string id);
        List<Domain> getDomains();
          Domain FindDomain(string id);

        

    }
}