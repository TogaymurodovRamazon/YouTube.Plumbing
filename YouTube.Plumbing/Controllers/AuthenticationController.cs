using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Identity;

namespace YouTube.Plumbing.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IMapper _mapper;

        private readonly IValidator<LogInVM> _logInValidator;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationController(UserManager<AppUser> userManager, IValidator<SignUpVM> signUpValidator, IMapper mapper, IValidator<LogInVM> logInValidator, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signUpValidator = signUpValidator;
            _mapper = mapper;

            _logInValidator = logInValidator;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {
            var validator = await _signUpValidator.ValidateAsync(request);
            if (!validator.IsValid)
            {
                validator.AddToModelState(this.ModelState);
                return View();
            }
            var user = _mapper.Map<AppUser>(request);
            var userCreateResult = await _userManager.CreateAsync(user, request.Password);
            if (!userCreateResult.Succeeded)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(userCreateResult.Errors);
                return View();
            }
            return RedirectToAction("LogIn", "Authentication");
        }


        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Dashboard", new { Area = ("Admin") });
            var validator = await _logInValidator.ValidateAsync(request);
            if (!validator.IsValid)
            {
                
                validator.AddToModelState(this.ModelState);
                return View();
            }

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if(hasUser == null)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(new List<string> { "Email or Password is wrong." });
                return View();
            }

            var logInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);
            if(logInResult.Succeeded)
            {
                return Redirect(returnUrl!);
            }

            if (logInResult.IsLockedOut)
            {
                ViewBag.Result = "LockedOut";
                ModelState.AddModelErrorList(new List<string> { "Your account is locked Out for 60 seconds!" });
                return View();
            }
            ViewBag.Result = "FailedAttempt";
            ModelState.AddModelErrorList(new List<string> { $"Email or Password is wrong! Failed attempt{await _userManager.GetAccessFailedCountAsync(hasUser)}"});
            return View();
        } 
    }
}
