using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamanStore.Domain.Entities;

namespace SamanStore.Infrastructure.Persistance.SeedData;

public class GenerateSeedData
{
    #region SeedDataAsync
    public static async Task SeedDataAsync(SamanStoreDbContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!await context.ProductBrands.AnyAsync())
            {
                var ProductBrands = new List<ProductBrand>()
                {
                    new ProductBrand()
                    {
                        Title = "ProductBrand1",
                    },
                    new ProductBrand()
                    {
                        Title = "ProductBrand2",
                    }
                };
            }
            if (!await context.ProductTypes.AnyAsync())
            {
                var ProductTypes = new List<ProductType>()
                {
                    new ProductType()
                    {
                        Title = "ProductType1",
                    },
                    new ProductType()
                    {
                        Title = "ProductType2",
                    }
               };
            }
            if (!await context.Products.AnyAsync())
            {
                var products = FillProducts();
            }
        }
        catch (Exception e)
        {
            var loggger = loggerFactory.CreateLogger<GenerateSeedData>();
            loggger.LogError(e, "Error for SeedData");

        }
    }
    #endregion

    #region FillProducts
    private static IEnumerable<Product> FillProducts()
    {
        var products = new List<Product>()
                {
                    new Product()
                    {
                        Title = "Product1",
                        Price= 1000000,
                        Count=15,
                        ProductBrandId=1,
                        ProductTypeId=1,
                        PictureUrl=""
                    },
                    new Product()
                    {
                        Title = "Product2",
                        Price= 1000000,
                        Count=15,
                        ProductBrandId=1,
                        ProductTypeId=1,
                        PictureUrl=""
                    },
                    new Product()
                    {
                        Title = "Product3",
                        Price= 1000000,
                        Count=15,
                        ProductBrandId=2,
                        ProductTypeId=2,
                        PictureUrl=""
                    },
                    new Product()
                    {
                        Title = "Product4",
                        Price= 1000000,
                        Count=15,
                        ProductBrandId=2,
                        ProductTypeId=2,
                        PictureUrl=""
                    }
                };
        return products;
    }
    #endregion

}
