using clubyApi.Models;

namespace clubyApi.Services
{
    public interface IUserService
    {
        User Authentificate(Authentification user);
        User Register(User user);
        User FindUserByEmail(string email);
    }
}