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
    [HttpGet("/stylists")]
    public ActionResult Stylists()
    {
      List<Stylist> employees = Stylist.GetAll();
      return View(employees);
    }
    //input field for new stylist
    [HttpGet("/stylists/new")]
    public ActionResult NewStylist()
    {
      return View();
    }
    //creates new stylist and saves it to database
    [HttpPost("/stylists")]
    public ActionResult AddStylist()
    {
      Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
      newStylist.Save();
      return View("Stylists",Stylist.GetAll());
    }
    //Deletes all stylists
    [HttpGet("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll();
      return View("Stylists");
    }
    //List clients for seleted stylists
    [HttpGet("/stylists/{id}/clients")]
    public ActionResult StylistClients(int id)
    {
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);
      return View(myModel);
    }
    //form to add clients to stylist
    [HttpGet("/stylists/{id}/clients/new/")]
    public ActionResult NewClient(int id)
    {
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);
      return View(myModel);
    }
    //return to client list page for stylist
    [HttpPost("/stylists/{id}/clients/")]
    public ActionResult AddClients(int id)
    {
      Client newClient = new Client(Request.Form["client-name"],id);
      newClient.Save();
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);

      return View("StylistClients",myModel);
    }
    //remove selected client and show client list for current stylist
    [HttpPost("/stylists/{id}/clients/{clientId}/remove/")]
    public ActionResult RemoveClient(int id, int clientId)
    {
      Client.Delete(clientId);
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
    //input updates to client from stylist client list
    [HttpGet("/stylists/{id}/clients/{clientId}/update/")]
    public ActionResult UpdateClient(int id , int clientId)
    {
      StylistClientsViewModel myModel = new StylistClientsViewModel(id,clientId);
      return View(myModel);
    }
    //implement updates to client
    [HttpPost("/stylists/{id}/clients/{clientId}/updated")]
    public ActionResult ChangeClient(int id , int clientId)
    {
      string newName=null;
      int newStylist=0;
      
      if (!String.IsNullOrEmpty(Request.Form["client-name"]))
      {newName = Request.Form["client-name"];}
      if (!String.IsNullOrEmpty(Request.Form["client-stylist"]))
      {newStylist = Int32.Parse(Request.Form["client-stylist"]);}

      Client.Find(clientId).Update(newName,newStylist);
      StylistClientsViewModel myModel = new StylistClientsViewModel(id);
      return View("StylistClients",myModel);
    }
  }
}
