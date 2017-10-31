// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using HairSalon.Controllers;
// using HairSalon.Models;
//
// namespace HairSalon.Tests
// {
//     [TestClass]
//     public class HomeControllerTest
//     {
//       [TestMethod]
//       public void Index_ReturnsCorrectView_True()
//       {
//       //Arrange
//       HomeController controller = new HomeController();
//
//       //Act
//       IActionResult indexView = controller.Index();
//       ViewResult result = indexView as ViewResult;
//
//       //Assert
//       Assert.IsInstanceOfType(result, typeof(ViewResult));
//       }
//       [TestMethod]
//       public void Index_HasCorrectModelType_StylistList()
//       {
//         //Arrange
//         ViewResult indexView = new HomeController().Index() as ViewResult;
//
//         //Act
//         var result = indexView.ViewData.Model;
//
//         //Assert
//         Assert.IsInstanceOfType(result, typeof(List<Stylist>));
//       }
//     }
// }
