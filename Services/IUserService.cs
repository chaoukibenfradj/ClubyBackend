using System.Collections.Generic;
using clubyApi.Models;
using ClubyBackend.Models;

namespace clubyApi.Services
{
    public interface IUserService
    {
        User Authentificate(Authentification user);
        User Register(User user);
        User FindUserByEmail(string email);
        List<Email> FindEmailBySenderId(string id);
        List<Email> FindEmailByReceiverId(string id);
       Email SendEmail(EmailDto email);
        User FindUserById(string id);

    }
}