using System.Collections.Generic;
using clubyApi.Models;
using clubyApi.Repositories;
using MongoDB.Driver;

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
        public   List<Domain> getDomains(){
            return _repo.getDomains();
        }

        public UpdateResult ModifyDomain(Domain domain)
        {
            return _repo.ModifyDomain(domain);
        }

        public Domain FindDomain(string id){
            return _repo.FindDomain(id);
        }
    }
}