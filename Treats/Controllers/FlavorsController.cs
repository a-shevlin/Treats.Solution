using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Treats.Models;
using System.Collections.Generic;
using System.Linq;

namespace Treats.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly TreatsContext _db;

    public FlavorsController(TreatsContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index() 
    { 
      ViewBag.PageTitle = ("Pierre's Treats");
      ViewBag.Header = ("All Flavors's");
      List<Flavor> model = _db.Flavors.ToList();
      return View(model); 
    }
    public ActionResult Create()
    {
      ViewBag.PageTitle = ("Pierre's Treats");
      ViewBag.Header = ("Add New Flavor");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var model = _db.Flavors
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      ViewBag.PageTitle = ("Pierre's Treats");
      ViewBag.Header = (model.FlavorName);
      return View(model);
    }

    public ActionResult AddTreat(int id)
    {
      var model = _db.Flavors
        .Include(flavor => flavor.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      ViewBag.PageTitle = ("Pierre's Treats");
      ViewBag.Header = ("Add A Treat!");
      return View(model);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      if(TreatId != 0 && !_db.TreatFlavors.Any(model => model.FlavorId == flavor.FlavorId && model.TreatId == TreatId))
      {
        _db.TreatFlavors.Add(new TreatFlavor() {TreatId = TreatId, FlavorId = flavor.FlavorId});
        _db.SaveChanges();
      }
      return RedirectToAction("AddTreat");
    }

    [HttpPost]
    public ActionResult DeleteTreat(int joinId, int id) 
    {
      var joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      var model = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View("Details", model);
    }

    public ActionResult Edit(int id)
    {
      var model = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var model = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var model = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id );
      _db.Flavors.Remove(model);
      _db.SaveChanges();
      return RedirectToAction("Index");  
    }
  }
}