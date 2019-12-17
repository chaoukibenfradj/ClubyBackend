using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface IDomainRepository
    {
        public Domain CreateDomain(Domain domain);
        public Domain ModifyDomain(string id,Domain domain);
        public Domain DeleteDomain(string id);

        

    }
}