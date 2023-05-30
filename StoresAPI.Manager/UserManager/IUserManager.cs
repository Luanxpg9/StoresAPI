using StoresAPI.DTO.User;

namespace StoresAPI.Manager.UserManager
{
    public interface IUserManager
    {
        // Create
        Task<UserDTO> CreateNewUser(NewUserDTO newUser);

        // Read
        Task<UserDTO> FindUserByUsername(string username);
        Task<UserDTO> GetUserById(uint id);
        Task<IList<UserDTO>> GetAll(int itensPerPage, int Page);
        Task<IList<UserDTO>> ListUserByStoreId(uint storeId, int itensPerPage, int Page);
        
        // Update
        Task<UserDTO> UpdateUser(UserUpdateDTO userUpdate);
        Task<bool> ToggleUser(uint userId);

        // Delete
        Task RemoveUser(uint userId);
    }
}
