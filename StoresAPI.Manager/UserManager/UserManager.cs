using StoresAPI.Domain.Models;
using StoresAPI.DTO.User;
using StoresAPI.Repository.BaseRepository;
using StoresAPI.Util;

namespace StoresAPI.Manager.UserManager
{
    public class UserManager : IUserManager
    {
        #region Constructor
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserStore> _userStoreRepository;
        private readonly IRepository<Store> _storeRepository;

        public UserManager(IRepository<User> userRepository, IRepository<UserStore> userStoreRepository, IRepository<Store> storeRepository)
        {
            _userRepository = userRepository;
            _userStoreRepository = userStoreRepository;
            _storeRepository = storeRepository;
        }
        #endregion

        #region Create
        public async Task<UserDTO> CreateNewUser(NewUserDTO newUser)
        {
            try
            {
                // Check if user is already registered
                var foundUser = await _userRepository.SearchAsync(
                    u => u.CPF == newUser.CPF.Trim() || 
                    u.Username.ToLower() == newUser.Username.ToLower().Trim());
                

                if (foundUser.Count > 0)
                {
                    throw new InvalidDataException("User already registered");
                }

                var user = new User
                {
                    Name = newUser.Name.Trim(),
                    Username = newUser.Username.Trim().ToLower(),
                    CPF = newUser.CPF.Trim(),
                    Password = newUser.Password.Trim(),
                    IsActive = newUser.IsActive
                };

                // Validators
                var validator = new UserValidator();

                var result = await validator.ValidateAsync(user);

                if (!result.IsValid)
                {
                    throw new InvalidDataException(result.Errors.First().ErrorMessage);
                }

                // Hash the password
                user.Password = MD5Helper.CreateHashMD5(user.Password);

                // Remove special characters from cpf
                user.CPF = user.CPF.Replace(".", "").Replace("-", "");

                // Register user
                var registeredUser = await _userRepository.AddAsync(user);

                // Map user to userDTO
                var userDTO = new UserDTO
                {
                    Id = registeredUser.Id,
                    Name = registeredUser.Name,
                    Username = registeredUser.Username,
                    CPF = registeredUser.CPF,
                    CreationDate = registeredUser.CreatingDate,
                    IsActive = registeredUser.IsActive
                };

                return userDTO;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Read
        public async Task<UserDTO> FindUserByUsername(string username)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(username))
                {
                    throw new InvalidDataException("Please provide a valid username");
                }

                var foundUserList = await _userRepository.SearchAsync(u => u.Username.ToLower().Equals(username.ToLower().Trim()));
                var foundUser = foundUserList.FirstOrDefault();

                if (foundUser == null)
                {
                    throw new KeyNotFoundException("Could not find a user with the given username");
                }

                // Map User to UserDTO
                var userDTO = new UserDTO
                {
                    Id = foundUser.Id,
                    Name = foundUser.Name,
                    Username = foundUser.Username,
                    CPF = foundUser.CPF,
                    CreationDate = foundUser.CreatingDate,
                    IsActive = foundUser.IsActive
                };

                return userDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<UserDTO>> GetAll()
        {
            var userList = await _userRepository.GetAllAsync();

            if (!userList.Any())
                throw new Exception("There are no registered users");

            var userListDTO = new List<UserDTO>();

            foreach (var user in userList)
            {
                var newUserDTO = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    CPF = user.CPF,
                    CreationDate = user.CreatingDate,
                    IsActive = user.IsActive
                };

                userListDTO.Add(newUserDTO);
            }

            return userListDTO;
        }

        public async Task<IList<UserDTO>> GetAll(int itensPerPage, int Page)
        {
            var userList = await _userRepository.GetAllAsync(itensPerPage, Page);

            if (!userList.Any())
                throw new Exception("There are no registered users");

            var userListDTO = new List<UserDTO>();

            foreach (var user in userList)
            {
                var newUserDTO = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    CPF = user.CPF,
                    CreationDate = user.CreatingDate,
                    IsActive = user.IsActive
                };

                userListDTO.Add(newUserDTO);
            }

            return userListDTO;
        }

        public async Task<UserDTO> GetUserById(uint id)
        {
            var foundUser = await _userRepository.GetByIdAsync(id);

            if (foundUser == null) throw new KeyNotFoundException("Could not find any user with the given id");

            // Map user to userDTO
            var userDTO = new UserDTO
            {
                Id = foundUser.Id,
                Name = foundUser.Name,
                Username = foundUser.Username,
                CPF = foundUser.CPF,
                CreationDate = foundUser.CreatingDate,
                IsActive = foundUser.IsActive
            };

            return userDTO;
        }

        public async Task<IList<UserDTO>> ListUserByStoreId(uint storeId)
        {
            // Find Store
            var foundStore = await _storeRepository.GetByIdAsync(storeId);
            if (foundStore == null) throw new KeyNotFoundException("Could not find a store with the given Id");

            // Find userStore
            var foundUserStore = await _userStoreRepository.SearchAsync(us => us.StoreId == storeId);
            if (foundUserStore.Count == 0) throw new KeyNotFoundException("Could not find any user for the given store");

            var userListDTO = new List<UserDTO>(); 

            foreach (var userStore in foundUserStore)
            {
                // Find user
                var foundUser = await _userRepository.GetByIdAsync(userStore.UserId);

                // Map user to userDTO
                var userDTO = new UserDTO
                {
                    Id = foundUser!.Id,
                    Name = foundUser!.Name,
                    Username = foundUser!.Username,
                    CPF = foundUser!.CPF,
                    CreationDate = foundUser!.CreatingDate,
                    IsActive = foundUser!.IsActive
                };

                // Add to the list
                userListDTO.Add(userDTO);
            }

            return userListDTO;
        }

        public async Task<IList<UserDTO>> ListUserByStoreId(uint storeId, int itensPerPage, int Page)
        {
            // Find Store
            var foundStore = await _storeRepository.GetByIdAsync(storeId);
            if (foundStore == null) throw new KeyNotFoundException("Could not find a store with the given Id");

            // Find userStore
            var foundUserStore = await _userStoreRepository.SearchAsync(us => us.StoreId == storeId, itensPerPage, Page);
            if (foundUserStore.Count == 0) throw new KeyNotFoundException("Could not find any user for the given store");

            var userListDTO = new List<UserDTO>();

            foreach (var userStore in foundUserStore)
            {
                // Find user
                var foundUser = await _userRepository.GetByIdAsync(userStore.UserId);

                // Map user to userDTO
                var userDTO = new UserDTO
                {
                    Id = foundUser!.Id,
                    Name = foundUser!.Name,
                    Username = foundUser!.Username,
                    CPF = foundUser!.CPF,
                    CreationDate = foundUser!.CreatingDate,
                    IsActive = foundUser!.IsActive
                };

                // Add to the list
                userListDTO.Add(userDTO);
            }

            return userListDTO;
        }

        #endregion

        #region Update
        public async Task<UserDTO> UpdateUser(UserUpdateDTO userUpdate)
        {
            var foundUser = await _userRepository.GetByIdAsync(userUpdate.Id);
            if (foundUser == null) throw new KeyNotFoundException("Could not find a user with the given Id");

            // Map values to foundUser
            if (!String.IsNullOrWhiteSpace(userUpdate.Name)) foundUser.Name = userUpdate.Name;
            if (!String.IsNullOrWhiteSpace(userUpdate.Username))
            {
                // Check if there is another user with the new username
                var invalidUserList = await _userRepository.SearchAsync(u => u.Username.ToLower().Equals(userUpdate.Username.ToLower().Trim()) && u.Id != userUpdate.Id);
                if (invalidUserList.Any()) throw new InvalidDataException($"User already registered with username {userUpdate.Username}");

                foundUser.Username = userUpdate.Username.Trim();
            } 
            if (!String.IsNullOrWhiteSpace(userUpdate.CPF))
            {
                // Check if there is another user with the new CPF
                var invalidUserList = await _userRepository.SearchAsync(u => u.CPF.Equals(userUpdate.CPF.Trim()) && u.Id != userUpdate.Id);
                if (invalidUserList.Any()) throw new InvalidDataException($"User already registered with CPF {userUpdate.CPF}");

                foundUser.CPF = userUpdate.CPF.Trim();
            }
            if (!String.IsNullOrWhiteSpace(userUpdate.Password)) foundUser.Password = userUpdate.Password;
            if (userUpdate.IsActive != null) foundUser.IsActive = userUpdate.IsActive.Value;


            // Validators
            var validator = new UserValidator();

            var result = await validator.ValidateAsync(foundUser);

            if (!result.IsValid)
            {
                throw new InvalidDataException(result.Errors.First().ErrorMessage);
            }

            // Hash the password
            foundUser.Password = MD5Helper.CreateHashMD5(foundUser.Password);

            // Remove special characters from cpf
            foundUser.CPF = foundUser.CPF.Replace(".", "").Replace("-", "");

            var updatedUser = await _userRepository.UpdateAsync(foundUser);

            // Map UpdatedUser to UserDTO
            var userDTO = new UserDTO
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Username = updatedUser.Username,
                CPF = updatedUser.CPF,
                CreationDate = updatedUser.CreatingDate,
                IsActive = updatedUser.IsActive
            };

            return userDTO;
        }


        public async Task<bool> ToggleUser(uint userId)
        {
            // Find user
            var foundUser = await _userRepository.GetByIdAsync(userId);
            if (foundUser == null) throw new KeyNotFoundException("Could not find any user with the given Id");

            // Toggle Active
            foundUser.IsActive = !foundUser.IsActive;
            await _userRepository.UpdateAsync(foundUser);

            // Return current state
            return !foundUser.IsActive;

        }

        #endregion
        public async Task RemoveUser(uint userId)
        {
            // Exclusive for SystemAdm
            await _userRepository.RemoveAsync(userId);
        }

    }
}
