using DesafioDevBackEnd.Domain.Entities;
using DesafioDevBackEnd.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        #region Protected Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            LoadingSeed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected static void LoadingSeed(ModelBuilder modelBuilder)
        {
            new Seed().UserSeed(modelBuilder.Entity<TransactionType>());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created_At") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created_At").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Updated_At").CurrentValue = DateTime.Now;
                    entry.Property("Updated_At").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
