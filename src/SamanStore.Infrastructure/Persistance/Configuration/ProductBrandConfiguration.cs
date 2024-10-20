using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamanStore.Domain.Entities;

namespace SamanStore.Infrastructure.Persistance.Configuration;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    #region Configure
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        #region Annotation
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Summary).HasMaxLength(500);
        #endregion
    }
    #endregion
}
