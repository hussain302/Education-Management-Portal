using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.PersonMappers;
using PortalMappers.PortalMapperes;
using PortalModels.WebModels;
using System;
using System.Linq;

namespace PortalAdmin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeService;
        private readonly IDepartmentRepository departmentService;

        public EmployeeController(IEmployeeRepository employeeService, IDepartmentRepository departmentService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
        }
        public IActionResult Manage()
        {
            var modelList = employeeService.GetEmployees().Select(x => x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No Employee Added Yet!";
                return View();
            }
        }


        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.departments = departmentService.GetDepartments().Select(x => x.ToModel()).ToList();

            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Employee";
                return View(employeeService.GetEmployee(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Employee";
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(EmployeeModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = employeeService.UpdateEmployee(model.ToDb());
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
                var response = employeeService.AddEmployee(model.ToDb());
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
            ViewData["Title"] = "Delete Employee";
            var find = employeeService.GetEmployee(id).ToModel();
            return View(find);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeModel model)
        {
            var response = employeeService.RemoveEmployee(model.Id);
            if (response)
            {
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Message = "Record didn't Deleted!";
            return RedirectToAction(nameof(Manage));
        }
        public IActionResult Details(int id)
        {

            ViewData["Title"] = "Employee Details";
            return View(employeeService.GetEmployee(id).ToModel());
        }
    }
}
