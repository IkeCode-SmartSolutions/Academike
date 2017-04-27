using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IkeCode.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Academike.Web.ViewModels;

namespace Academike.Web.Controllers
{
    [Route("/conta")]
    public class AccountController : Controller
    {
        //private readonly IRepository<Test> _userRepository;
        private readonly UserManager<IcUser> _userManager;
        private readonly SignInManager<IcUser> _signInManager;
        private readonly string _externalCookieScheme;

        public AccountController(/*IRepository<Test> userRepository*/
            UserManager<IcUser> userManager,
            SignInManager<IcUser> signInManager,
            IOptions<IdentityCookieOptions> identityCookieOptions)
        {
            //_userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;
        }

        [AllowAnonymous]
        [Route("/login")]
        public async Task<IActionResult> LoginAsync(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);

            ViewData["ReturnUrl"] = returnUrl;

            return View("Login");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                if(model.UserNameOrEmail.Contains("@"))
                {
                    var user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
                    if (user != null)
                        model.UserNameOrEmail = user.UserName;
                }

                var result = await _signInManager.PasswordSignInAsync(model.UserNameOrEmail, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tentativa de login inválida. Tente novamente.");
                    return View("Login", model);
                }
            }

            return View("Login", model);
        }

        [AllowAnonymous]
        [Route("cadastre-se")]
        public IActionResult SignUp()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar-conta")]
        public async Task<IActionResult> SignUpAsync(SignUpViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new IcUser
                    {
                        FullName = model.Name,
                        UserName = model.Email,
                        Email = model.Email
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                        // Send an email with this link
                        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var callbackUrl = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                        //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                        //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");

                        await _signInManager.SignInAsync(user, isPersistent: true);
                        return RedirectToAction("LoginAsync");
                    }
                    AddErrors(result);
                }
                
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("esqueci-minha-senha")]
        public async Task<IActionResult> LostPasswordAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("LoginAsync");
                }

                //TODO else!!! \/

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                //var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var callbackUrl = Url.Action(nameof(ResetPassword), "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                //   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                //return View("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("LoginAsync");
        }

        [AllowAnonymous]
        [Route("acesso-negado")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("sair")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction(nameof(AccountController.LoginAsync), "Account");
        }
    }
}