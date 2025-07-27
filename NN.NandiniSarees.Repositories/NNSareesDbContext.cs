using Microsoft.EntityFrameworkCore;
using NN.NandiniSarees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Repositories
{
    public class NNSareesDbContext : DbContext
    {
        public NNSareesDbContext(DbContextOptions<NNSareesDbContext> options) : base(options) { }
        public DbSet<Sarees> Sarees { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
