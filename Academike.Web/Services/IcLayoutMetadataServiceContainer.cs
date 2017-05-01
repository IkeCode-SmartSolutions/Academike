using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academike.Web.Services
{
    public interface IIcLayoutMetadataServiceContainer
    {
        IIcBreadcrumbService BreadcrumbService { get; }
        IIcPageMetadataService PageMetadataService { get; }
        IIcPageHeaderSearchService PageHeaderSearchService { get; }
        IIcPageHeaderButtonsService PageHeaderButtonsService { get; }
    }

    public class IcLayoutMetadataServiceContainer : IIcLayoutMetadataServiceContainer
    {
        public IIcBreadcrumbService BreadcrumbService { get; private set; }
        public IIcPageMetadataService PageMetadataService { get; private set; }
        public IIcPageHeaderSearchService PageHeaderSearchService { get; private set; }
        public IIcPageHeaderButtonsService PageHeaderButtonsService { get; private set; }

        public IcLayoutMetadataServiceContainer(
            IIcBreadcrumbService breadcrumbService,
            IIcPageMetadataService pageMetadataService,
            IIcPageHeaderSearchService pageHeaderSearchService,
            IIcPageHeaderButtonsService pageHeaderButtonsService)
        {
            BreadcrumbService = breadcrumbService;
            PageMetadataService = pageMetadataService;
            PageHeaderSearchService = pageHeaderSearchService;
            PageHeaderButtonsService = pageHeaderButtonsService;
        }
    }
}
