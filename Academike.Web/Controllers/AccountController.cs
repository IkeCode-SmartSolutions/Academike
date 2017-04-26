using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Academike.Web.Controllers
{
    [Route("/conta")]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [Route("/login")]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [Route("cadastre-se")]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastre-se")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        [Route("acesso-negado")]
        public ActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("sair")]
        public ActionResult LogOut()
        {
            //TODO

            return RedirectToAction("Login");
        }
    }
}