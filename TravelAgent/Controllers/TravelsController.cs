using Microsoft.AspNetCore.Mvc;
using TravelAgent.Models;

namespace TravelAgent.Controllers;

public class TravelsController : Controller
{
  public IActionResult Index()
  {
    List<Travel> travels = Travel.GetTravels();
    return View(travels);
  }

  public IActionResult Details(int id)
  {
    Travel travel = Travel.GetDetails(id);
    return View(travel);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Travel travel)
  {
    Travel.Post(travel);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Travel travel = Travel.GetDetails(id);
    return View(travel);
  }

  [HttpPost]
  public ActionResult Edit(Travel travel)
  {
    Travel.Put(travel);
    return RedirectToAction("Details", new { id = travel.TravelId});
  }

  public ActionResult Delete(int id)
  {
    Travel travel = Travel.GetDetails(id);
    return View(travel);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Travel.Delete(id);
    return RedirectToAction("Index");
  }

  
}