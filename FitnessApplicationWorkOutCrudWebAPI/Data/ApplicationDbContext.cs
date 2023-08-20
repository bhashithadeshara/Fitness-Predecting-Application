using FitnessApplicationWorkOutCrudWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FitnessApplicationWorkOutCrudWebAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WorkOutDetail> WorkOutDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }
    }
}
