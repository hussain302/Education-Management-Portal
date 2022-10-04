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
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentService;
        private readonly IProgramRepository programService;

        public StudentController(IStudentRepository studentService, IProgramRepository programService)
        {
            this.studentService = studentService;
            this.programService = programService;
        }

        public IActionResult Manage()
        {
            try
            {

                var modelList = studentService.GetStudents().Select(x => x.ToModel()).ToList();
                if (modelList.Count > 0) return View(modelList);
                else
                {
                    ViewBag.message = "No Student Added Yet!";
                    return View();

                }
            }
            catch
            {
                ViewBag.message = "No Student Added Yet!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            try
            {
                ViewBag.programs = programService.GetPrograms().Select(x => x.ToModel()).ToList();

                if (id > 0)
                {
                    //Edit Record
                    ViewData["Title"] = "Edit Student";
                    return View(studentService.GetStudent(Convert.ToInt32(id)).ToModel());
                }
                else
                {
                    //Create new record
                    ViewData["Title"] = "Create Student";
                    return View();
                }
            }
            catch
            {
                ViewData["Title"] = "Error Loading Component";
                return View("CreateOrEdit");
            }
        }


        [HttpPost]
        public IActionResult CreateOrEdit(StudentModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = studentService.UpdateStudent(model.ToDb());
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
                var response = studentService.AddStudent(model.ToDb());
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
            ViewData["Title"] = "Delete Student";
            return View(studentService.GetStudent(id).ToModel());
        }
        [HttpPost]
        public IActionResult Delete(StudentModel model)
        {
            var response = studentService.RemoveStudent(model.Id);
            if (response)
            {
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Message = "Record didn't Deleted!";
            return RedirectToAction(nameof(Manage));
        }
        public IActionResult Details(int id)
        {

            ViewData["Title"] = "Student Details";
            return View(studentService.GetStudent(id).ToModel());
        }
    }
}