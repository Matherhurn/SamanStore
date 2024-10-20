using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamanStore.Domain.Entities;

namespace SamanStore.Infrastructure.Persistance.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    #region Configure
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        #region Annotation
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PictureUrl).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Summary).HasMaxLength(500);
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasOne(x => x.ProductType).WithMany().HasForeignKey(x => x.ProductTypeId);
        builder.HasOne(x => x.ProductBrand).WithMany().HasForeignKey(x => x.ProductBrandId);
        #endregion
    }
    #endregion
}
