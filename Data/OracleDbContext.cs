using Checkpoint.Model;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint.Data
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .Property(p => p.Tipo)
                .HasConversion<string>(); 
        }
    }
}
