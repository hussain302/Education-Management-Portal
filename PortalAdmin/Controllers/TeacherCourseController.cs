using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAdmin.Controllers
{
    public class TeacherCourseController : Controller
    {
        private readonly ITeacherCourseRepostory mainService;

        public TeacherCourseController(ITeacherCourseRepostory mainService)
        {
            this.mainService = mainService;
        }

        public IActionResult Manage()
        {
            return View();
        }
    }
}
