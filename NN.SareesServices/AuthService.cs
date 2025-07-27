using NN.NandiniSarees.Models;
using NN.NandiniSarees.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.SareesServices
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        public AuthService(IUsersRepository usersRepository) => _usersRepository = usersRepository;

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _usersRepository.GetByUsernameAsync(username);
            if (user == null) return null;

            // Use a secure password hash comparison here
            if (password.ToLower() == user.PasswordHash.ToLower())
                return user;

            return null;
        }
    }
}
