using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.PersonMappers;
using PortalMappers.PortalMapperes;
using PortalModels.WebModels;
using PortalRepositories.PortalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAdmin.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseRepository mainService;
        private readonly ICourseRepository courseService;
        private readonly IStudentRepository teacherService;

        public StudentCourseController(IStudentCourseRepository mainService,
            ICourseRepository courseService, IStudentRepository teacherService)
        {
            this.mainService = mainService;
            this.courseService = courseService;
            this.teacherService = teacherService;
        }

        public IActionResult Manage()
        {
            ViewData["Title"] = "Student - Course Assigning Managment";
            dynamic modelList = null;
            try { modelList = mainService.GetStudentCourses().Select(x => x.ToModel()).ToList();  }
            catch { modelList = null;
                TempData["message"] = "No Data found";
            }
            return View(modelList);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.courses = courseService.GetCourses().Select(x => x.ToModel()).ToList();
            ViewBag.students = teacherService.GetStudents().Select(x => x.ToModel()).ToList();

            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Record";
                return View(mainService.GetStudentCourse(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Record";
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(StudentCourseModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    //Edit Record
                    var response = mainService.UpdateStudentCourse(model.ToDb());
                    if (response)
                    {
                        return RedirectToAction(nameof(Manage));
                    }
                    TempData["message"] = "Record didn't Updated!";
                    return View();
                }
                else
                {
                    //Create new record
                    var response = mainService.AddStudentCourse(model.ToDb());
                    if (response)
                    {
                        return RedirectToAction(nameof(Manage));
                    }
                    else 
                    {
                        TempData["message"] = "Record didn't Created!";
                        return RedirectToAction(nameof(Manage));
                    }        
                }
            }
            catch
            {
                TempData["message"] = "Record didnt Created!";
                return RedirectToAction(nameof(Manage));
            }
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            ViewBag.courses = courseService.GetCourses().Select(x => x.ToModel()).ToList();
            ViewBag.teachers = teacherService.GetStudents().Select(x => x.ToModel()).ToList();

            //Delete Record
            ViewData["Title"] = "Delete Record";
            return View(mainService.GetStudentCourse(Convert.ToInt32(id)).ToModel());
        }

        [HttpPost]
        public IActionResult Delete(TeacherCourseModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    //Edit Record
                    var response = mainService.DeleteStudentCourse(model.Id);
                    if (response)
                    {
                        TempData["message"] = "Record Deleted Successfully!";
                        return RedirectToAction(nameof(Manage));
                    }
                    else
                    {
                        TempData["message"] = "Record didn't Deleted!";
                        return RedirectToAction(nameof(Manage));
                    }
                }                
            }
            catch
            {
                TempData["message"] = "Record didnt Deleted!";
                return RedirectToAction(nameof(Manage));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            ViewBag.courses = courseService.GetCourses().Select(x => x.ToModel()).ToList();
            ViewBag.students = teacherService.GetStudents().Select(x => x.ToModel()).ToList();

            //Delete Record
            ViewData["Title"] = "Details Record";
            return View(mainService.GetStudentCourse(Convert.ToInt32(id)).ToModel());
        }

    }
}
