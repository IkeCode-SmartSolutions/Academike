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
                Books = books.Select(i => new BookFormViewModel(i.Id, LayoutMetadataService)
                {
                    Name = i.Title,
                    Description = i.Description
                })
            };

            return View("Index", vm);
        }

        [Route("{id:int?}")]
        public IActionResult Get(int id)
        {
            LayoutMetadataService.PageMetadataService.AddTitle("Cadernos");
            LayoutMetadataService.BreadcrumbService.Add("Cadernos");

            if (id == 0)
            {
                ViewData["Title"] = "Novo -> Caderno";
                LayoutMetadataService.BreadcrumbService.Add("Novo");
            }
            else
            {
                ViewData["Title"] = string.Format("Editando -> Caderno #{0}", id);
                LayoutMetadataService.BreadcrumbService.Add("Editar");
            }

            var vm = new BookFormViewModel(id, LayoutMetadataService);

            if (id > 0)
            {
                var book = _bookRepository.Get(id);

                vm = new BookFormViewModel(id, LayoutMetadataService)
                {
                    Id = book.Id,
                    Name = book.Title,
                    Description = book.Description
                };
            }

            return View("Form", vm);
        }

        [HttpGet]
        [Route("{id:int}/remover")]
        public IActionResult Delete(int id)
        {
            _bookRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(BookFormViewModel model)
        {
            Book book;

            if (model.Id == 0)
            {
                book = new Book()
                {
                    Title = model.Name,
                    Description = model.Description,
                    Owner = SessionUser
                };
            }
            else
            {
                book = _bookRepository.Get(model.Id);
                book.Title = model.Name;
                book.Description = model.Description;
            }

            _bookRepository.Upsert(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
