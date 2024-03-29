using clubyApi.Models;

namespace clubyApi
{
    public interface IAdministrationService
    {
        Administration CreateAdmin(Administration administration);
        Administration ModifyAdmin(string id,string administration);
        Administration DeleteAdmin(string id);
        Administration FindAdminProfile(string id);

      Administration FindAdmin(string id);
    }
}