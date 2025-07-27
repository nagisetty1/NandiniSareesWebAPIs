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
        private readonly IUsersJWTTokenRepository _usersJWTTokenRepository;
        public AuthService(IUsersRepository usersRepository, IUsersJWTTokenRepository usersJWTTokenRepository) 
        {
            _usersRepository = usersRepository;
            _usersJWTTokenRepository = usersJWTTokenRepository;
        }

        public async Task<UserJWTToken?> AuthenticateAsync(string username, string password)
        {
            var userUI = new UserJWTToken();
            var user = await _usersRepository.GetByUsernameAsync(username);
            if (user == null) return null;

            // Use a secure password hash comparison here
            if (password.ToLower() == user.PasswordHash.ToLower())
            {

                userUI.Username = user.Username;
                userUI.UserId = user.Id;
                userUI.EmailId = user.Email;
                userUI = await _usersJWTTokenRepository.AddAsync(userUI);
                return userUI;
            }

            return null;
        }
    }
}
