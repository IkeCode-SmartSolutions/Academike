using Academike.Web.Services;
using System.Collections.Generic;

namespace Academike.Web.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public BookViewModel() : base() { }

        public BookViewModel(IIcLayoutMetadataServiceContainer layoutMetadataService)
            : base(layoutMetadataService)
        {
            LayoutMetadataService.PageMetadataService.AddTitle("Cadernos");
            LayoutMetadataService.BreadcrumbService.Add("Cadernos");
            LayoutMetadataService.BreadcrumbService.Add("Meus Cadernos");

            var btnNovo = new ButtonMetadata("Novo")
            {
                Icon = "ion-plus-round"
            };
            btnNovo.AddCustomAttribute("data-toggle", "modal");
            btnNovo.AddCustomAttribute("data-target", "#book-form-modal");

            LayoutMetadataService.PageHeaderButtonsService.Add(btnNovo);
        }

        public BookFormViewModel Form { get; set; }
        public IEnumerable<BookFormViewModel> Books {get;set; }
}
}
