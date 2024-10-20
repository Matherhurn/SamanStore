using Microsoft.EntityFrameworkCore;
using SamanStore.Domain.Entities;
using System.Reflection;

namespace SamanStore.Infrastructure.Persistance;

public class SamanStoreDbContext : DbContext
{
    #region Methods

    #region Constructore
    public SamanStoreDbContext(DbContextOptions<SamanStoreDbContext>options) :base(options)
    {
        
    }
    #endregion

    #region Override
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    #endregion

    #endregion

    #region DbSets
    DbSet<Product> Products => Set<Product>();
    DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();
    DbSet<ProductType> ProductTypes => Set<ProductType>();
    #endregion 
}
