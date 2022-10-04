using Microsoft.AspNetCore.Mvc;
using PortalInterfaces.IPortalRepositories;
using PortalMappers.UserMappers;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAdmin.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository service;

        public RoleController(IRoleRepository service)
        {
            this.service = service;
        }

        public IActionResult Manage()
        {
            var modelList = service.GetRoles().Select(x => x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No Roles Added Yet!";
                return View();
            }
        }
        public IActionResult CreateOrEdit(int? id)
        {
            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Role";
                return View(service.GetRole(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Role";
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateOrEdit(RoleModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = service.UpdateRole(model.ToDb());
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
                var response = service.AddRole(model.ToDb());
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
            ViewData["Title"] = "Delete Role";
            return View(service.GetRole(id).ToModel());
        }
        [HttpPost]
        public IActionResult Delete(RoleModel model)
        {
            var response = service.RemoveRole(model.Id);
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
            ViewData["Title"] = "Details Role";
            return View(service.GetRole(id).ToModel());
        }
    }
}