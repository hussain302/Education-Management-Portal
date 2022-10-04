using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.PortalMapperes;
using PortalModels.WebModels;
using System;
using System.Linq;

namespace PortalAdmin.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseService;
        private readonly IProgramRepository programService;

        public CourseController(ICourseRepository courseService, IProgramRepository programService)
        {
            this.courseService = courseService;
            this.programService = programService;
        }

        public IActionResult Manage()
        {
            var modelList = courseService.GetCourses().Select(x=>x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No Course Added Yet!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.programs  = programService.GetPrograms().Select(x => x.ToModel()).ToList();

            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Course";
                return View(courseService.GetCourse(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Course";
                return View();
            }
        }


        [HttpPost]
        public IActionResult CreateOrEdit(CoursesModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = courseService.UpdateCourse(model.ToDb());
                if (response)
                {
                    return RedirectToAction(nameof(Manage));
                }
                ViewBag.Message = "Record didn't Updated!";
                return View();
            }
            else
            {
                //Create new record
                var response = courseService.AddCourse(model.ToDb());
                if (response)
                {
                    return RedirectToAction(nameof(Manage));
                }
                ViewBag.Message = "Record didn't Created!";
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Delete Course";
            return View(courseService.GetCourse(id).ToModel());
        }
        [HttpPost]
        public IActionResult Delete(CoursesModel model)
        {
            var response = courseService.RemoveCourse(model.Id);
            if (response)
            {
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Message = "Record didn't Deleted!";
            return RedirectToAction(nameof(Manage));
        }
        public IActionResult Details(int id)
        {
   
            ViewData["Title"] = "Course Details";
            return View(courseService.GetCourse(id).ToModel());
        }
    }
}
