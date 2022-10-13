using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.PersonMappers;
using PortalMappers.PortalMapperes;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAdmin.Controllers
{
    public class TeacherCourseController : Controller
    {
        private readonly ITeacherCourseRepostory mainService;
        private readonly ICourseRepository courseService;
        private readonly ITeacherRepository teacherService;

        public TeacherCourseController(ITeacherCourseRepostory mainService,
            ICourseRepository courseService, ITeacherRepository teacherService)
        {
            this.mainService = mainService;
            this.courseService = courseService;
            this.teacherService = teacherService;
        }

        public IActionResult Manage()
        {
            ViewData["Title"] = "Teacher - Course Assigning Managment";
            dynamic modelList = null;
            try { modelList = mainService.GetTeachersCourses().Select(x => x.ToModel()).ToList();  }
            catch { modelList = null;
                ViewBag.message = "No Data found";
            }

            return View(modelList);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.courses = courseService.GetCourses().Select(x => x.ToModel()).ToList();
            ViewBag.teachers = teacherService.GetTeachers().Select(x => x.ToModel()).ToList();

            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Record";
                return View(mainService.GetTeacherCourse(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Record";
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(TeacherCourseModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    //Edit Record
                    var response = mainService.UpdateTeacherCourse(model.ToDb());
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
                    var response = mainService.AddTeacherCourse(model.ToDb());
                    if (response)
                    {
                        return RedirectToAction(nameof(Manage));
                    }
                    ViewBag.Message = "Record didn't Created!";
                    return RedirectToAction(nameof(Manage));
                }
            }
            catch
            {
                ViewBag.message = "Record didnt Created!";
                return RedirectToAction(nameof(Manage));
            }
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            ViewBag.courses = courseService.GetCourses().Select(x => x.ToModel()).ToList();
            ViewBag.teachers = teacherService.GetTeachers().Select(x => x.ToModel()).ToList();

            //Delete Record
            ViewData["Title"] = "Delete Record";
            return View(mainService.GetTeacherCourse(Convert.ToInt32(id)).ToModel());
        }

        [HttpPost]
        public IActionResult Delete(TeacherCourseModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    //Edit Record
                    var response = mainService.DeleteTeacherCourse(model.Id);
                    if (response)
                    {
                        ViewBag.Message = "Record Deleted Successfully!";
                        return RedirectToAction(nameof(Manage));
                    }
                    else
                    {
                        ViewBag.Message = "Record didn't Deleted!";
                        return RedirectToAction(nameof(Manage));
                    }
                }                
            }
            catch
            {
                ViewBag.message = "Record didnt Deleted!";
                return RedirectToAction(nameof(Manage));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            ViewBag.courses = courseService.GetCourses().Select(x => x.ToModel()).ToList();
            ViewBag.teachers = teacherService.GetTeachers().Select(x => x.ToModel()).ToList();

            //Delete Record
            ViewData["Title"] = "Details Record";
            return View(mainService.GetTeacherCourse(Convert.ToInt32(id)).ToModel());
        }

    }
}
