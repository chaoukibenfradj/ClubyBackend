using clubyApi.Models;
using clubyApi.Repositories;

namespace clubyApi.Services
{
    public class DomainService : IDomainService
    {
          private  readonly IDomainRepository _repo;
        public DomainService(IDomainRepository repo)
        {
            _repo=repo ;

        }
        public Domain CreateDomain(Domain domain)
        {
            return _repo.CreateDomain(domain);
        }

        public Domain DeleteDomain(string id)
        {
            return _repo.DeleteDomain(id);
        }

        public Domain ModifyDomain(string id, Domain domain)
        {
           return _repo.ModifyDomain(id,domain);
        }
    }
}