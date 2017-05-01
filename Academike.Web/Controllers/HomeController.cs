using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Academike.Web.Services;

namespace Academike.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IIcLayoutMetadataServiceContainer layoutMetadataService)
            : base(layoutMetadataService)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
