using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]               //define url
    public ActionResult Index() //send class with two strings to Hello.cshtml
    {

      return View();
    }


  }
}
