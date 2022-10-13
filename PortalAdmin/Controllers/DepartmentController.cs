using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.PortalMapperes;
using PortalModels.WebModels;

namespace PortalAdmin.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository service;

        public DepartmentController(IDepartmentRepository service)
        {
            this.service = service;
        }

        
        public IActionResult Manage()
        {
            var modelList = service.GetDepartments().Select(x => x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No Department Added Yet!";
                return View();
            }
        }
        public IActionResult CreateOrEdit(int? id)
        {
            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Department";
                return View(service.GetDepartment(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Department";
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateOrEdit(DepartmentModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = service.UpdateDepartment(model.ToDb());
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
                var response = service.AddDepartment(model.ToDb());
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
            //Edit Record
            ViewData["Title"] = "Delete Department";
            return View(service.GetDepartment(id).ToModel());
        }
        [HttpPost]
        public IActionResult Delete(DepartmentModel model)
        {
            var response = service.RemoveDepartment(model.Id);
            if (response)
            {
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Message = "Record didn't Deleted!";
            return RedirectToAction(nameof(Manage));
        }

        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Department Details";
            return View(service.GetDepartment(id).ToModel());
        }
    }
}