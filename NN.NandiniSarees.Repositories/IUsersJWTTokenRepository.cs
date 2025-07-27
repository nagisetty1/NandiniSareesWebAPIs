using Microsoft.IdentityModel.JsonWebTokens;
using NN.NandiniSarees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Repositories
{
    public interface IUsersJWTTokenRepository
    {
        Task<UserJWTToken?> GetByUsernameOrEmailAsync(string usernameOrUserIdOrEmail);
        Task<UserJWTToken> AddAsync(UserJWTToken  userJWTToken);
    }
}
