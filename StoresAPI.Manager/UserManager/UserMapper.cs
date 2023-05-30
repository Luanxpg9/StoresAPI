using StoresAPI.Domain.Models;
using StoresAPI.DTO.User;

namespace StoresAPI.Manager.UserManager
{
    public static class UserMapper
    {

        #region User <-> UserDTO
        public static UserDTO UserToUserDTO(User user)
        {
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                CPF = user.CPF,
                CreationDate = user.CreatingDate,
                IsActive = user.IsActive
            };

            return userDTO;
        }

        public static User UserDtoToUser(UserDTO userDTO)
        {
            var user = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Username = userDTO.Username,
                CPF = userDTO.CPF,
                CreatingDate = userDTO.CreationDate,
                IsActive = userDTO.IsActive
            };

            return user;
        }
        #endregion

        #region NewUserDTO -> User
        public static User NewUserDtoToUser (NewUserDTO newUser)
        {
            var user = new User
            {
                Name = newUser.Name.Trim(),
                Username = newUser.Username.Trim(),
                CPF = Util.Util.RemoveDashesAndDots(newUser.CPF.Trim()),
                Password = newUser.Password.Trim(),
                IsActive = newUser.IsActive
            };

            return user;
        }
        #endregion

        #region UserUpdateDTO -> User
        public static User UserUpdateToUser (UserUpdateDTO userUpdate, User user)
        {
            user.Id = userUpdate.Id;
            if (!String.IsNullOrWhiteSpace(userUpdate.Name)) 
                user.Name = userUpdate.Name.Trim();

            if (!String.IsNullOrWhiteSpace(userUpdate.CPF)) 
                user.CPF = Util.Util.RemoveDashesAndDots(userUpdate.CPF.Trim());

            if (!String.IsNullOrWhiteSpace(userUpdate.Username)) 
                user.Name = userUpdate.Username.Trim();

            if (userUpdate.IsActive != null)
                user.IsActive = userUpdate.IsActive.Value;

            return user;
        }
        #endregion
    }
}
