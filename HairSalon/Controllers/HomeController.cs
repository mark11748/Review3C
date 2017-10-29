using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    //front page
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    //list of stylists
    [HttpGet("/Stylists")]
    public ActionResult Stylists()
    {
      List<Stylist> employees = Stylist.GetAll();
      return View(employees);
    }
    //input field for new stylist
    [HttpGet("/Stylists/new")]
    public ActionResult NewStylist()
    {
      return View();
    }
    //creates new stylist and saves it to database
    [HttpPost("/Stylists")]
    public ActionResult AddStylist()
    {
      Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
      newStylist.Save();
      return View("Stylists",Stylist.GetAll());
    }
    //Deletes all stylists
    [HttpGet("/Stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll();
      return View("Stylists");
    }
    //List clients for seleted stylists
    [HttpGet("/Stylists/{id}")]
    public ActionResult StylistClients(int id)
    {
      return View();
    }


  }
}
