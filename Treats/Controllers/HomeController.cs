using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Treats.Models;
using System.Dynamic;
using System.Linq;

namespace Treats.Controllers
{
  public class HomeController : Controller
  {
    private readonly TreatsContext _db;

    public HomeController(TreatsContext db)
    {
      _db = db;
    }
    [HttpGet("/")]
    public ActionResult Index() 
    { 
      dynamic model = new ExpandoObject();
      model.Treat = _db.Treats.ToList();
      model.Flavor = _db.Flavors.ToList();
      ViewBag.PageTitle = ("Pierre's Treats");
      ViewBag.Header = ("Welcome to Pierre's!");
      return View(model); 
    }
  }
}