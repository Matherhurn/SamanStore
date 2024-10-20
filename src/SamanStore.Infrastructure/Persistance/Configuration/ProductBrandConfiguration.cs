using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamanStore.Domain.Entities;

namespace SamanStore.Infrastructure.Persistance.Configuration;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    #region Configure
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        throw new NotImplementedException();
    }
    #endregion
}
