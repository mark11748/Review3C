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
            Stylist.DeleteAll();
            Client.DeleteAll();
          }
      //TEST: two stylist are only equivalent if their properties match
      //  [TestMethod]
      //  public void EqualityTest_StylistEqualityOverload_DiffId()
      //  {
      //    Stylist employeeA = new Stylist("bob",0);
      //    Stylist employeeB = new Stylist("bob",1);
       //
      //    Assert.AreEqual(true, !employeeA.Equals(employeeB));
      //  }
      //  [TestMethod]
      //  public void EqualityTest_StylistEqualityOverload_DiffName()
      //  {
      //    Stylist employeeA = new Stylist("bob",0);
      //    Stylist employeeB = new Stylist("smith",0);
      //    Console.WriteLine(employeeA.GetName()+" : "+employeeB.GetName());
      //    Assert.AreEqual(true, !employeeA.Equals(employeeB));
      //  }
      //  [TestMethod]
      //  public void EqualityTest_StylistEqualityOverload_TrueCase()
      //  {
      //    Stylist employeeA = new Stylist("bob",0);
      //    Stylist employeeB = new Stylist("bob",0);
      //
      //    Assert.AreEqual(true, employeeA.Equals(employeeB));
      //  }

      //TEST: get list of all stylists
      [TestMethod]
      public void GetAll_Stylists_Empty()
      {
        Stylist newStylist = new Stylist("joe");
        newStylist.Save();
        int result = Stylist.GetAll().Count;

        foreach (Stylist x in Stylist.GetAll()) { Console.WriteLine(x.GetId() + " : "+x.GetName()); }

        Assert.AreEqual(1, result );
      }

      //TEST: create obj stylist on database from a passed instance of stylist
      // [TestMethod]
      // public void Save_Stylist()
      // {
      //   Stylist newStylist = new Stylist("bill");
      //
      //   newStylist.Save();
      //
      //   List<Stylist> stylistList = Stylist.GetAll();
      //   Assert.AreEqual(0, Stylist.GetAll);
      //}
   }
}
