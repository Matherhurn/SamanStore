using SamanStore.Domain.Entities.Base;

namespace SamanStore.Domain.Entities;

public class ProductBrand : BaseAduitableEntity,ICommand
{
    #region Master Property
    public string Title { get; set; }
    #endregion

    #region  Command Property
    public bool IsActive { get; set; }
    public string Dummary { get; set; }
    public bool IsDelete { get; set; }
    public string Description { get; set; }
    #endregion
}
