using Microsoft.EntityFrameworkCore;
using NN.NandiniSarees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Repositories
{
    public class SareesRepository : ISareesRepository
    {
        private readonly NNSareesDbContext _context;

        public SareesRepository(NNSareesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sarees>> GetAllAsync()
        {
            return await _context.Sarees.ToListAsync();
        }

        public async Task<Sarees?> GetByIdAsync(int id)
        {
            return await _context.Sarees.FindAsync(id);
        }

        public async Task AddAsync(Sarees saree)
        {
            _context.Sarees.Add(saree);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sarees saree)
        {
            _context.Sarees.Update(saree);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var saree = await _context.Sarees.FindAsync(id);
            if (saree != null)
            {
                _context.Sarees.Remove(saree);
                await _context.SaveChangesAsync();
            }
        }
    }
}
