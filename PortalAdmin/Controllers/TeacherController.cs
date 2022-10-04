using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.PersonMappers;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAdmin.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository teacherService;
        private readonly IQualificationRepository qualificationService;

        public TeacherController(ITeacherRepository teacherService, IQualificationRepository qualificationService)
        {
            this.teacherService = teacherService;
            this.qualificationService = qualificationService;
        }
        
        public IActionResult Manage()
        {
            var modelList = teacherService.GetTeachers().Select(x => x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No Teacher Added Yet!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.qualifications = qualificationService.GetQualifications().Select(x => x.ToModel()).ToList();

            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Teacher";
                return View(teacherService.GetTeacher(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Teacher";
                return View();
            }
        }


        [HttpPost]
        public IActionResult CreateOrEdit(TeacherModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = teacherService.UpdateTeacher(model.ToDb());
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
                var response = teacherService.AddTeacher(model.ToDb());
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
            ViewData["Title"] = "Delete Teacher";
            return View(qualificationService.GetQualification(id).ToModel());
        }
        [HttpPost]
        public IActionResult Delete(CoursesModel model)
        {
            var response = teacherService.RemoveTeacher(model.Id);
            if (response)
            {
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Message = "Record didn't Deleted!";
            return RedirectToAction(nameof(Manage));
        }
        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Teacher Details";
            return View(teacherService.GetTeacher(id).ToModel());
        }
    }
}
