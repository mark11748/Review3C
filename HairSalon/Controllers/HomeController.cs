using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.ViewModels;

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
    [HttpGet("/Stylists/Clients/{id}")]
    public ActionResult StylistClients(int id)
    {
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);
      return View(myModel);
    }
    //form to add clients to stylist
    [HttpGet("/Stylists/Clients/NewClient/{id}")]
    public ActionResult NewClient(int id)
    {
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);
      return View(myModel);
    }
    //return to client list page for stylist
    [HttpPost("/Stylists/Clients/{id}")]
    public ActionResult AddClients(int id)
    {
      Client newClient = new Client(Request.Form["client-name"],id);
      newClient.Save();
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);

      return View("StylistClients",myModel);
    }
    //form to select client to delete
    [HttpGet("/Stylists/Clients/DEL/{id}")]
    public ActionResult DeleteClient(int id)
    {
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);
      return View(myModel);
    }
    [HttpPost("/Stylists/Clients/DEL/{id}")]
    public ActionResult RemoveClient(int id)
    {
      Client.Delete(Int32.Parse(Request.Form["client-id"]));
      // //create the new table
      // List<Client> masterList = Client.GetAll();
      // int index = 0;
      // foreach (Client a in masterList)
      // { index++; if(Request.Form["client-id"] == a.GetId()){ masterList.RemoveAt(index); } }
      // //remove old table
      // Client.DeleteAll();
      // //save the new table
      // foreach(Client a in masterList){ a.Save(); }

      StylistClientsViewModel myModel = new StylistClientsViewModel(id);
      return View("StylistClients",myModel);
    }

  }
}
