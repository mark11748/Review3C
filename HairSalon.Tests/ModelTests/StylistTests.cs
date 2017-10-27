using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

   [TestClass]
   public class StylistTests : IDisposable
   {
       public StylistTests()
       {
           DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_woodward_test;";
       }
        public void Dispose()
       {
        //  Stylist.DeleteAll();
        //  Client.DeleteAll();
       }
       //two stylist are only equivalent if their properties match
       [TestMethod]
       public void EqualityTest_StylistEqualityOverload_DiffId()
       {
         Stylist employeeA = new Stylist("bob",0);
         Stylist employeeB = new Stylist("bob",1);

         Assert.AreEqual(true, !employeeA.Equals(employeeB));
       }
       [TestMethod]
       public void EqualityTest_StylistEqualityOverload_DiffName()
       {
         Stylist employeeA = new Stylist("bob",0);
         Stylist employeeB = new Stylist("smith",0);
         Console.WriteLine(employeeA.GetName()+" : "+employeeB.GetName());
         Assert.AreEqual(true, !employeeA.Equals(employeeB));
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
