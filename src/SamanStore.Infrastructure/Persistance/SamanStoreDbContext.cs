using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SamanStore.Domain.Entities;
using SamanStore.Domain.Entities.Base;
using System.Reflection;
using System.Threading;

namespace SamanStore.Infrastructure.Persistance;

public class SamanStoreDbContext : DbContext
{
    #region Methods

    #region Constructore
    public SamanStoreDbContext(DbContextOptions<SamanStoreDbContext>options) :base(options)
    {
        
    }
    #endregion

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    #endregion

    #region Sava Change Async
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries<BaseAduitableEntity>())
        {
            entity.Entity.LastModified = DateTime.Now;
    
            if (entity.State == EntityState.Added)
            {
                entity.Entity.Created = DateTime.Now;
                entity.Entity.CreatedBy = 1;
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    #endregion

    #region Save Change
    public override int SaveChanges()
    {
        foreach (var entity in ChangeTracker.Entries<BaseAduitableEntity>())
        {
            entity.Entity.LastModified = DateTime.Now;
            if (entity.State == EntityState.Added)
            {
                entity.Entity.Created = DateTime.Now;
                entity.Entity.CreatedBy = 1;
            }
        }
        return base.SaveChanges();
    }
    #endregion

    #endregion

    #region DbSets
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();
    #endregion
}
