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
    public class QualificationController : Controller
    {
        private readonly IQualificationRepository service;

        public QualificationController(IQualificationRepository service)
        {
            this.service = service;
        }

        public IActionResult Manage()
        {
            var modelList = service.GetQualifications().Select(x => x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No Qualification Added Yet!";
                return View();
            }
        }

        public IActionResult CreateOrEdit(int? id)
        {
            if (id > 0)
            {
                //Edit Record
                ViewData["Title"] = "Edit Department";
                return View(service.GetQualification(Convert.ToInt32(id)).ToModel());
            }
            else
            {
                //Create new record
                ViewData["Title"] = "Create Department";
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateOrEdit(QualificationModel model)
        {
            if (model.Id > 0)
            {
                //Edit Record
                var response = service.UpdateQualiofication(model.ToDb());
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
                var response = service.AddQualiofication(model.ToDb());
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
            ViewData["Title"] = "Delete Qualification Record";
            return View(service.GetQualification(id).ToModel());
        }
        [HttpPost]
        public IActionResult Delete(QualificationModel model)
        {
            var response = service.RemoveQualiofication(model.Id);
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
            ViewData["Title"] = "Qualification Details";
            return View(service.GetQualification(id).ToModel());
        }
    }
}
