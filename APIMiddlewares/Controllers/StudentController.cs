using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalModels.ResponceModels;
using System;
using System.Linq;
using PortalMappers.PersonMappers;
using System.Threading.Tasks;

namespace APIMiddlewares.Controllers
{
    [Route("Middlewares/")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository repo;

        public StudentController(IStudentRepository repo)
        {
            this.repo = repo;
        }

        #region Student MiddleWares

        [HttpGet]
        [Route("RetriveStudents-Program")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client, VaryByHeader = "User-Agent")]
        public IActionResult GetStudent()
        {
            try
            {
                var modelList = repo.GetStudents().Select(x => x.ToModel());
                if (modelList != null)
                {
                    return Ok( new Result<dynamic>
                    {
                        data = modelList,
                        message = "Students list fetched Successfully",
                        success = true
                    });
                }
                else
                    return BadRequest(new Result<dynamic> { message = "Students list not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new Result<dynamic>
                {
                    success = true,
                    message = ex.Message,
                    data = null
                });
            }
        }


        #endregion

    }
}
