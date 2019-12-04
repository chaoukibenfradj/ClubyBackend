using clubyApi.Models;

namespace clubyApi.Repositories
{
    public interface IAdministrationRepository
    {
        Administration createAdministration(Administration user);
    }
}