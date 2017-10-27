using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

   [TestClass]
   public class EmployeeTests : IDisposable
   {
       public EmployeeTests()
       {
           DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_woodward_test;";
       }
        public void Dispose()
       {
         Task.DeleteAll();
         Category.DeleteAll();
       }

       [TestMethod]
       public void EqualityTest_StylistEqualityOverload_DiffId()
       {
         Stylist employeeA = new Stylist("bob",0);
         Stylist employeeB = new Stylist("bob",1);

         Assert.AreEqual(true, employeeA.Equals(employeeB));
       }
       [TestMethod]
       public void EqualityTest_StylistEqualityOverload_DiffName()
       {
         Stylist employeeA = new Stylist("bob",0);
         Stylist employeeB = new Stylist("smith",0);

         Assert.AreEqual(true, employeeA.Equals(employeeB));
       }
       [TestMethod]
       public void EqualityTest_StylistEqualityOverload_TrueCase()
       {
         Stylist employeeA = new Stylist("bob",0);
         Stylist employeeB = new Stylist("bob",0);

         Assert.AreEqual(true, employeeA.Equals(employeeB));
       }



   }
}
