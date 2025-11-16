using EventUber.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventUber.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}

        public DbSet<Topic> Topics => Set<Topic>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Tenant> Tenants => Set<Tenant>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()!.ToLowerInvariant());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName()!.ToLowerInvariant());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName()!.ToLowerInvariant());
                }

                foreach (var fk in entity.GetForeignKeys())
                {
                    fk.SetConstraintName(fk.GetConstraintName()!.ToLowerInvariant());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName()!.ToLowerInvariant());
                }
            }
        }

    }
}