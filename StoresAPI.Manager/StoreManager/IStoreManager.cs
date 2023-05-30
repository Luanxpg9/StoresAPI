namespace StoresAPI.Manager.StoreManager
{
    public interface IStoreManager
    {
        #region Create
        Task<StoreDTO> CreateNewStore(NewStoreDTO newStore);
        #endregion
    }
}
