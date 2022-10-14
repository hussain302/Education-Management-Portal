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
            try
            {
                var modelList = courseService.GetCourses().Select(x => x.ToModel()).ToList();
                if (modelList.Count > 0) return View(modelList);
                else
                {
                    ViewBag.message = "No Course Added Yet!";
                    return View();
                }
            }
            catch
            {
                TempData["message"] = "No Data Found";
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.programs = programService.GetPrograms().Select(x => x.ToModel()).ToList();

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
            try
            {
                if (model.Id > 0)
                {

                    //Edit Record
                    var response = courseService.UpdateCourse(model.ToDb());
                    if (response)
                    {
                        return RedirectToAction(nameof(Manage));
                    }
                    else
                    {
                        TempData["message"] = "Updation failed";
                        return RedirectToAction(nameof(Manage));
                    }
                }
                else
                {
                    //Create new record
                    var response = courseService.AddCourse(model.ToDb());
                    if (response)
                    {
                        return RedirectToAction(nameof(Manage));
                    }
                    else
                    {
                        TempData["message"] = "Updation failed";
                        return RedirectToAction(nameof(Manage));
                    }
                    
                    //return View();
                }
            }
            catch
            {
                TempData["message"] = "Operation failed";
                return RedirectToAction(nameof(Manage));
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
            try
            {
                var response = courseService.RemoveCourse(model.Id);
                if (response)
                {
                    return RedirectToAction(nameof(Manage));
                }
                else
                {
                    TempData["message"] = "Course is alreday assigned to other instance!";
                    return RedirectToAction(nameof(Manage));
                }
               
               // return RedirectToAction(nameof(Manage));
            }
            catch
            {
                TempData["message"] = "Deletion failed";
                return RedirectToAction(nameof(Manage));
            }
        }
        public IActionResult Details(int id)
        {

            ViewData["Title"] = "Course Details";
            return View(courseService.GetCourse(id).ToModel());
        }
    }
}
