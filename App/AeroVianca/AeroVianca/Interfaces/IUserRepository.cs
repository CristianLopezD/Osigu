using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AeroVianca.Model;

namespace AeroVianca.Interfaces
{
    public interface IUserRepository
    {
        string AuthenticateUser(NetworkCredential credential);
        string Add(UserModel userModel);
        UserModel GetByUsername(string username);

    }
}
