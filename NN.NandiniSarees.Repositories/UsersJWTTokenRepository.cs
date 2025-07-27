using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NN.NandiniSarees.Models;
using NN.NandiniSarees.Repositories;
namespace NN.NandiniSarees.Repositories
{
    public class UsersJWTTokenRepository : IUsersJWTTokenRepository
    {
        private readonly NNSareesDbContext _context;
        public UsersJWTTokenRepository(NNSareesDbContext context) => _context = context;

        public async Task<UserJWTToken?> GetByUsernameOrEmailAsync(string usernameOrUserIdOrEmail)
        {
            var userJWTToken = await _context.UserJWTToken.FirstOrDefaultAsync(u => u.Username == usernameOrUserIdOrEmail || u.EmailId == usernameOrUserIdOrEmail);
            return userJWTToken;
        }

        public async Task<UserJWTToken> AddAsync(UserJWTToken userJWTToken)
        {
            int result = 0;
            var existingToken =  await _context.UserJWTToken.FirstOrDefaultAsync(u => u.Username == userJWTToken.Username || u.EmailId == userJWTToken.EmailId);
            if(existingToken == null)
            {
                userJWTToken.JWTToken = Guid.NewGuid();
                _context.UserJWTToken.Add(userJWTToken);
                result = await _context.SaveChangesAsync();
            }
            else
            {
                existingToken.JWTToken = Guid.NewGuid();
                _context.UserJWTToken.Update(existingToken);
                result = await _context.SaveChangesAsync();
            }
            return await _context.UserJWTToken.FirstOrDefaultAsync(u => u.Username == userJWTToken.Username || u.EmailId == userJWTToken.EmailId);
        }
    }
}