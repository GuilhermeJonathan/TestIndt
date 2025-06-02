using Microsoft.EntityFrameworkCore;
using TestIndt.Domain.Entities;

namespace TestIndt.Infra.Data.Context
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
