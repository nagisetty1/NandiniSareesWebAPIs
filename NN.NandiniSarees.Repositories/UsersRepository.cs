using Microsoft.EntityFrameworkCore;
using NN.NandiniSarees.Models;
using NN.NandiniSarees.Repositories;
namespace NN.NandiniSarees.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly NNSareesDbContext _context;
        public UsersRepository(NNSareesDbContext context) => _context = context;

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Username == username || u.Email == username);

        public async Task<User?> ValidateUserAsync(string username, string password) =>
            await _context.Users.FirstOrDefaultAsync(u => (u.Username.ToLower() == username.ToLower() || u.Email.ToLower() == username.ToLower()) && u.PasswordHash == password);

        public async Task<int> AddAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }
    }
}