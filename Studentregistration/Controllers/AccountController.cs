using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Studentregistration.Context;
using Studentregistration.Models;

namespace Studentregistration.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly StudentDbcontext _studentDbContext;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, StudentDbcontext studentDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _studentDbContext = studentDbContext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register( AccountRegister model )
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Username,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _studentDbContext.Accounts!.Add(model);
                    _studentDbContext.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpGet]

        public IActionResult Loging()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Loging(Loging user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }




        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
