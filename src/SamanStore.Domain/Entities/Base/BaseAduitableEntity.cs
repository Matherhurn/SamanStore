namespace SamanStore.Domain.Entities.Base;

public class BaseAduitableEntity : BaseEntity
{
    #region Property
    public DateTime Created { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public int LastModifiedBy { get; set; }
    #endregion
}
