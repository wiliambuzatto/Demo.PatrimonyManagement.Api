using Demo.PatrimonyManagement.Data.Mapping;
using Demo.PatrimonyManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PatrimonyManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }

        public DbSet<User> User { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Patrimony> Patrimony { get; set; }
        public DbSet<LogEntry> LogEntry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserMap(modelBuilder.Entity<User>());
            new BrandMap(modelBuilder.Entity<Brand>());
            new PatrimonyMap(modelBuilder.Entity<Patrimony>());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.LogChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
