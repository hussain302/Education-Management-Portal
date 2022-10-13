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
    public class UserController : Controller
    {
        private readonly IUserRepository service;
        private readonly IRoleRepository roleService;

        public UserController(IUserRepository service, IRoleRepository roleService)
        {
            this.service = service;
            this.roleService = roleService;
        }


        [ResponseCache(Location = ResponseCacheLocation.Client, VaryByHeader = "User-Agent", Duration = 3600)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            var response = service.LoginUserRequest(model.Email, model.Password);
            if (response != null)
            {
                if (response.IsApproved)
                {
                    TempData["message"] = "Logged in successfully!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ViewBag.message = "User is not approved to login";
                    return View();
                }
            }
            else
            {
                ViewBag.message = "User not found";
                return View();
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            
            var response = service.GetUser(model.Email);
            if (response != null)
            {
                ViewBag.message = "User already exist try a different Email";
                return View();
            }
            else
            {
                TempData["message"] = "User request registed successfully - (wait for approval)";
                service.AddUser(model.ToDb());
                return RedirectToAction("Login");
            }
        }


        [HttpGet]
        public IActionResult Manage()
        {
            var modelList = service.GetUsers().Select(x => x.ToModel()).ToList();
            if (modelList.Count > 0) return View(modelList);
            else
            {
                ViewBag.message = "No User found!";
                return View();
            }
        }

    }
}
