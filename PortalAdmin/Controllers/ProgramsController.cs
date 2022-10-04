using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.PortalMapperes;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAdmin.Controllers
{
    public class ProgramsController : Controller
    {
        private readonly IProgramRepository programService;
        private readonly IDepartmentRepository deptService;

        public ProgramsController(IProgramRepository programService, IDepartmentRepository deptService)
        {
            this.programService = programService;
            this.deptService = deptService;
        }

        public IActionResult Manage()
        {
            var modelList = programService.GetPrograms().Select(x=>x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No Program Added Yet!";
                return View();
            }
        }

        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.departments = deptService.GetDepartments().Select(x=>x.ToModel()).ToList();

            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Program";
                return View(programService.GetProgram(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Program";
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateOrEdit(ProgramModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = programService.UpdateProgram(model.ToDb());
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
                var response = programService.AddProgram(model.ToDb());
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
            ViewData["Title"] = "Delete Program";
            return View(programService.GetProgram(id).ToModel());
        }
        [HttpPost]
        public IActionResult Delete(ProgramModel model)
        {
            var response = programService.RemoveProgram(model.Id);
            if (response)
            {
                return RedirectToAction(nameof(Manage));
            }
            ViewBag.Message = "Record didn't Deleted!";
            return RedirectToAction(nameof(Manage));
        }

        public IActionResult Details(int id)
        {
            //Edit Record
            ViewData["Title"] = "Program Details";
            return View(programService.GetProgram(id).ToModel());
        }
    }
}
