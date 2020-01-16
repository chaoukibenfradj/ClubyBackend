using System.Collections.Generic;
using clubyApi.Models;

namespace clubyApi.Services
{
    public interface IDomainService
    {
         Domain CreateDomain(Domain domain);
         Domain ModifyDomain(string id,Domain domain);
         Domain DeleteDomain(string id);
        List<Domain> getDomains();

        
    }
}