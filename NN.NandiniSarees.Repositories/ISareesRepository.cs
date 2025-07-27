using NN.NandiniSarees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Repositories
{
    public interface ISareesRepository
    {
        Task<IEnumerable<Sarees>> GetAllAsync();
        Task<Sarees?> GetByIdAsync(int id);
        Task AddAsync(Sarees saree);
        Task UpdateAsync(Sarees saree);
        Task DeleteAsync(int id);
    }
}
