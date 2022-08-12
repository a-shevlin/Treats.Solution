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
  public class TreatsController : Controller
  {
    private readonly TreatsContext _db;

    public TreatsController(TreatsContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index() 
    { 
      ViewBag.PageTitle = ("Pierre's Treats");
      ViewBag.Header = ("All Treat's");
      List<Treat> model = _db.Treats.ToList();
      return View(model); 
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = ("Pierre's Treats");
      ViewBag.Header = ("Create a Treat!");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var model = _db.Treats
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.PageTitle = ("Treat Details");
      ViewBag.Header = (@model.TreatName);
      return View(model);
    }

    public ActionResult AddFlavor(int id)
    {
      var model = _db.Treats
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(model);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      if(FlavorId != 0 && !_db.TreatFlavors.Any(model => model.TreatId == treat.TreatId && model.FlavorId == FlavorId))
      {
        _db.TreatFlavors.Add(new TreatFlavor() {FlavorId = FlavorId, TreatId = treat.TreatId});
        _db.SaveChanges();
      }
      return RedirectToAction("AddFlavor");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId, int id) 
    {
      var joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      var model = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View("Details", model);
    }

    public ActionResult Edit(int id)
    {
      var model = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.PageTitle = ("Edit Treat");
      ViewBag.Header = ("Edit " + @model.TreatName);
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var model = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.PageTitle = ("Delete Treat");
      ViewBag.Header = ("Are you sure you want to delete " + @model.TreatName + "?");
      return View(model);
    }

    public ActionResult DeleteConfirmed(int id)
    {
      return DeleteConfirmed(id);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id, string v)
    {
      var model = _db.Treats.FirstOrDefault(treat => treat.TreatId == id );
      _db.Treats.Remove(model);
      _db.SaveChanges();
      return RedirectToAction("Index");  
    }
  }
}