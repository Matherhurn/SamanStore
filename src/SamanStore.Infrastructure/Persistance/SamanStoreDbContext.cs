using Microsoft.EntityFrameworkCore;
using SamanStore.Domain.Entities;

namespace SamanStore.Infrastructure.Persistance;

public class SamanStoreDbContext : DbContext
{
    #region Methods

    #region Constructore
    public SamanStoreDbContext(DbContextOptions<SamanStoreDbContext>options) :base(options)
    {
        
    }
    #endregion

    #endregion

    #region DbSets
    DbSet<Product> Products => Set<Product>();
    #endregion
}
