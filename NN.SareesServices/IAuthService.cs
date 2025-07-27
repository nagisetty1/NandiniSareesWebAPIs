using NN.NandiniSarees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.SareesServices
{
    public interface IAuthService
    {
        Task<UserJWTToken?> AuthenticateAsync(string username, string password);
    }

}
