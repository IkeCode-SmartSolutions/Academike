using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Academike.Model;
using Academike.Web.Services;

namespace Academike.Web.Controllers
{
    public class BaseAuthController : BaseController
    {
        protected readonly UserManager<AcademikeUser> UserManager;
        protected AcademikeUser SessionUser;

        public BaseAuthController(UserManager<AcademikeUser> userManager, IIcLayoutMetadataServiceContainer layoutMetadataService)
            : base(layoutMetadataService)
        {
            UserManager = userManager ?? throw new ArgumentNullException("userManager");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            SessionUser = UserManager.GetUserAsync(User).Result;
        }
    }
}
