using NN.NandiniSarees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Repositories
{
    public interface IUsersRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> ValidateUserAsync(string username, string password);
        Task<int> AddAsync(User user);
    }
}
