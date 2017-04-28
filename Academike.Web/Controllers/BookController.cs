using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Academike.Model;
using IkeCode.Data;
using Academike.Data;

namespace Academike.Web.Controllers
{
    [Authorize]
    [Route("/cadernos")]
    public class BookController : Controller
    {
        private readonly Repository<Book> _bookRepository;

        public BookController(Repository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var a = _bookRepository.Get(1);
            return View();
        }
    }
}
