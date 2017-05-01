using Academike.Web.Services;
using System.Collections.Generic;

namespace Academike.Web.ViewModels
{
    public class BaseViewModel
    {
        protected readonly IIcLayoutMetadataServiceContainer LayoutMetadataService;

        protected BaseViewModel()
        {
        }

        public BaseViewModel(IIcLayoutMetadataServiceContainer layoutMetadataService)
            : this()
        {
            LayoutMetadataService = layoutMetadataService;
        }
    }
}
