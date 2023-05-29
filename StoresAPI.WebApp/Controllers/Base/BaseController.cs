using Microsoft.AspNetCore.Mvc;

namespace StoresAPI.WebApp.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public JsonResult Sucess(object entity, int statusCode = 200)
        {
            var result = new JsonResult(entity)
            {
                StatusCode = statusCode
            };

            return result;
        }

        [NonAction]
        public JsonResult Error(object entity, int statusCode = 500)
        {
            var result = new JsonResult(entity)
            {
                StatusCode = statusCode
            };

            return result;
        }
    }
}
