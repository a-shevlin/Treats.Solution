using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Treats.Models;
using System.Threading.Tasks;
using Treats.ViewModels;

namespace Treats.Controllers
{
  public class AccountController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TreatsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = ("Account Register");
      ViewBag.Header = ("Account Registry");
      return View();
    }

    public IActionResult Register()
    {
      ViewBag.PageTitle = ("Account Register");
      ViewBag.Header = ("Would You Like to Register?");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Registration Failed.";
        return View();
      }
    }

    public ActionResult Login()
    {
      ViewBag.PageTitle = ("Pierre's Login");
      ViewBag.Header = ("Please Login to Access all Pages.");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Unable to Login.";
        return View();
      }
    }

    public ActionResult LogOff()
    {
      ViewBag.PageTitle = ("Pierre's Log Out");
      ViewBag.Header = ("Log Out");
      return View();
    }

    [HttpPost, ActionName("LogOff")]
    public async Task<ActionResult> LogOffConfirm()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}