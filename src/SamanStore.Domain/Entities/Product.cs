
using SamanStore.Domain.Entities.Base;

namespace SamanStore.Domain.Entities;

public class Product : BaseAduitableEntity, ICommand
{
    #region Master Property
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string PictureUrl { get; set; }
    public bool IsOff { get; set; } = false;
    #endregion

    #region  Command Property
    public bool IsActive { get; set; } = true;
    public string Summary { get; set; }
    public bool IsDelete { get; set; } = false;
    public string Description { get; set; }
    #endregion

    #region Foregin Property
    public int ProductBrandId { get; set; }
    public ProductBrand ProductBrand { get; set; }
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    #endregion
}
