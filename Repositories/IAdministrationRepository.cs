using clubyApi.Models;

namespace clubyApi
{
    public interface IAdministrationRepository
    {
        Administration CreateAdmin(Administration administration);
        Administration ModifyAdmin(string id,string administration);
        Administration DeleteAdmin(string id);


 
    }
}