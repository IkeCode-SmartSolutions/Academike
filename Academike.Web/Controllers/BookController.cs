using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Academike.Model;
using Academike.Data;
using Academike.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Academike.Web.Services;

namespace Academike.Web.Controllers
{
    [Authorize]
    [Route("/cadernos")]
    public class BookController : BaseAuthController
    {
        private readonly Repository<Book> _bookRepository;

        public BookController(Repository<Book> bookRepository
                              , UserManager<AcademikeUser> userManager
                              , IIcLayoutMetadataServiceContainer layoutMetadataService)
            : base(userManager, layoutMetadataService)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.Get();

            var vm = new BookViewModel(LayoutMetadataService)
            {
                Books = books.Select(i => new BookFormViewModel()
                {
                    Id = i.Id,
                    Name = i.Title,
                    Description = i.Description
                })
            };
            
            return View(vm);
        }

        [Route("editar/{id:int?}")]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                ViewData["Title"] = "Novo -> Caderno";
            }
            else
            {
                ViewData["Title"] = string.Format("Editando -> Caderno #{0}", id);
            }

            var book = _bookRepository.Get(id);

            var vm = new BookFormViewModel(id, LayoutMetadataService)
            {
                Id = book.Id,
                Name = book.Title,
                Description = book.Description
            };

            return View("Form", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(BookFormViewModel model)
        {
            var book = new Book()
            {
                Title = model.Name,
                Description = model.Description,
                Owner = SessionUser
            };

            _bookRepository.Upsert(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
