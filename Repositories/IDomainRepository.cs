using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface IDomainRepository
    {
         Domain CreateDomain(Domain domain);
         Domain ModifyDomain(string id,Domain domain);
         Domain DeleteDomain(string id);
        List<Domain> getDomains();

        

    }
}