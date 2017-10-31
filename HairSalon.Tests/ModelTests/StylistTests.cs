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
         Assert.AreEqual(true, !employeeA.Equals(employeeB));
       }
       [TestMethod]
       public void EqualityTest_StylistEqualityOverload_TrueCase()
       {
         Stylist employeeA = new Stylist("bob",0);
         Stylist employeeB = new Stylist("bob",0);

         Assert.AreEqual(true, employeeA.Equals(employeeB));
       }

      [TestMethod]
      public void GetAll_Stylists_Empty()
      {
        Stylist newStylist = new Stylist("joe");
        newStylist.Save();
        int result = Stylist.GetAll().Count;

        Assert.AreEqual(1, result );
      }

      [TestMethod]
      public void Save_Stylist()
      {
        Stylist newStylist = new Stylist("bill");
        newStylist.Save();

        List<Stylist> stylistList = Stylist.GetAll();

        Assert.AreEqual(1, Stylist.GetAll().Count);
      }

      [TestMethod]
      public void DeleteAll_Stylist()
      {
        Stylist.DeleteAll();

        Assert.AreEqual(0,Stylist.GetAll().Count);


      }

      [TestMethod]
      public void Find_Stylist()
      {
        Stylist newStylistA = new Stylist("sam");
        newStylistA.Save();
        Stylist newStylistB = new Stylist("sally");
        newStylistB.Save();
        Stylist newStylistC = new Stylist("smith");
        newStylistC.Save();
        Stylist newStylistD = new Stylist("bob");
        newStylistD.Save();

        Assert.AreEqual(true,Stylist.Find(1).Equals(Stylist.GetAll()[0]));

      }
   }
}
