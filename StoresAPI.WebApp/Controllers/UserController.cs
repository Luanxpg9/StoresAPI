using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NLog;
using StoresAPI.DTO.User;
using StoresAPI.Manager.UserManager;
using StoresAPI.WebApp.Controllers.Base;

namespace StoresAPI.WebApp.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("[controller]/[action]")]
    public class UserController : BaseController
    {
        #region Contructor
        private readonly IUserManager _userManager;
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        #endregion

        [HttpPost]
        public async Task<JsonResult> CreateNewUser(NewUserDTO newUser)
        {
            try
            {
                var userCreated = await _userManager.CreateNewUser(newUser);

                log.Info($"New user created with id: {userCreated.Id}");
                return Sucess(userCreated, 201);
            }
            catch (InvalidDataException ex)
            {
                log.Error("Error while creating a new user: " + ex.Message);
                return Error(ex.Message, 400);
            }
            catch (Exception ex)
            {
                var message = "Error while creating a new user: ";
                
                // Checks for inner exception
                if (ex.InnerException != null)
                {
                    log.Error(message + ex.InnerException.Message);
                    return Error(ex.InnerException.Message);
                }

                log.Error(message + ex.Message);
                return Error(ex.Message);
            }
        }
    }
}
