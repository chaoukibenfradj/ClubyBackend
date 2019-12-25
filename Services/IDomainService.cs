using clubyApi.Models;

namespace clubyApi.Services
{
    public interface IDomainService
    {
        public Domain CreateDomain(Domain domain);
        public Domain ModifyDomain(string id,Domain domain);
        public Domain DeleteDomain(string id);
        public List<Domain> FindAllDomains();
    }
}