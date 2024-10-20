using SamanStore.Domain.Entities.Base;

namespace SamanStore.Domain.Entities;

public class ProductType : BaseAduitableEntity, ICommand
{
    #region Master Property
    public string Title { get; set; }
    #endregion

    #region  Command Property
    public bool IsActive { get; set; }
    public string Summary { get; set; }
    public bool IsDelete { get; set; }
    public string Description { get; set; }
    #endregion
}
