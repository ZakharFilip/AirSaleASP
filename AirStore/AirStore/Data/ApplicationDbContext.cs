using AirStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<SuperBusket> SuperBuskets { get; set; }
        public DbSet<ProdCharacter> ProdCharacters { get; set; }    

        public DbSet<Product> Products { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }


    }
}
