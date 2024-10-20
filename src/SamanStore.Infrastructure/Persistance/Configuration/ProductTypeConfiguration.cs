using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SamanStore.Domain.Entities;

namespace SamanStore.Infrastructure.Persistance.Configuration;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    #region  Configure
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        throw new NotImplementedException();
    }
    #endregion
}
