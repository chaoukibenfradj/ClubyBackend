using clubyApi.Models;

namespace clubyApi
{
    public interface IAdministrationRepository
    {
        Administration ModifyAdmin(string id,Administration administration);
        Administration DeleteAdmin(string id);


 
    }
}