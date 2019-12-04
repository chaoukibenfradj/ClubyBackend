using clubyApi.Models;
using clubyApi.Repositories;

namespace clubyApi.Services
{
    public class AdministrationService : IAdministrationService
    {  
        private readonly IAdministrationRepository _repo;
        public AdministrationService(IAdministrationRepository repo){
            _repo=repo;
            
        }
        public Administration createAdministration(Administration user)
        {
           return _repo.createAdministration(user);
        }
    }
}