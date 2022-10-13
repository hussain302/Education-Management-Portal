using Microsoft.AspNetCore.Mvc;
using PortalModels.ResponceModels;
using System.Threading.Tasks;

namespace APIMiddlewares.Controllers
{
    [Route("Api/Startup/")]
    public class StartupController : Controller
    {

        [Route("AppStarter")]
        public async Task<IActionResult> AppStarter()
        {
            return Ok(new Result<dynamic> {success = true, message= "API is working Successfully" });
        }




    }
}
