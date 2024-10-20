namespace SamanStore.Domain.Entities.Base
{
    public interface ICommand
    {
        #region Property
        public bool IsActive { get; set; }
        public string Summary { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
