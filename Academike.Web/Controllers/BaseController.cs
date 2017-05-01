using Academike.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Academike.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IIcLayoutMetadataServiceContainer LayoutMetadataService;

        public BaseController(IIcLayoutMetadataServiceContainer layoutMetadataService)
        {
            LayoutMetadataService = layoutMetadataService ?? throw new ArgumentNullException("layoutMetadataService");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            var pageModel = (context.Controller as Controller).ViewData.Model;

            //var model = (pageModel ?? new BaseViewModel()) as BaseViewModel;
            //if (pageModel == null)
            //{
            //    (context.Controller as Controller).ViewData.Model = model;
            //}
        }
    }
}
