using BackEndPetStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndPetStore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
