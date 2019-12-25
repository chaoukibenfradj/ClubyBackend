using clubyApi.Models;

namespace clubyApi
{
    public class AdministrationService : IAdministrationService
    {
        private  readonly IAdministrationRepository _repo;
        public AdministrationService(IAdministrationRepository repo)
        {
            _repo=repo ;

        }
        public Administration CreateAdmin(Administration administration)
        {
            return _repo.CreateAdmin(administration);
        }

        public Administration DeleteAdmin(string id)
        {
            return _repo.DeleteAdmin(id);
        }

        public Administration ModifyAdmin(string id, string administration)
        {
            return _repo.ModifyAdmin(id,administration);
        }

        public List<Administration> FindAllAdmins()
        {
           return _repo.FindAllAdmins();
        }
    }
}