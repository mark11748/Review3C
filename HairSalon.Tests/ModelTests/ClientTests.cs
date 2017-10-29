using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

 [TestClass]
 public class ClientTests : IDisposable
 {
    public ClientTests()
    {
       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_woodward_test;";
    }
      public void Dispose()
        {
          Stylist.DeleteAll();
          Client.DeleteAll();
        }
        [TestMethod]
        public void Save_Client()
        {
          Stylist Bob  = new Stylist("Bob");
          Bob.Save();
          Client  Alex = new Client ("Alex",Bob.GetId());
          Alex.Save();

          Assert.AreEqual(true,Alex.GetId()>0);
        }
        [TestMethod]
        public void GetAll_Client_Empty()
        {
          List<Client> resultList = Client.GetAll();

          Assert.AreEqual(true,resultList.Count == 0);
        }
        [TestMethod]
        public void GetAll_Client_HasClients()
        {
          Stylist stylistA = new Stylist("anna");
          stylistA.Save();
          Client clientA = new Client("bob",stylistA.GetId());
          clientA.Save();
          Client clientB = new Client("smith",stylistA.GetId());
          clientB.Save();

          List<Client> testList   = new List<Client>{clientA,clientB};
          List<Client> resultList = Client.GetAll();

          Console.WriteLine("testList   has: " + testList.Count   +" elements");
          foreach (Client x in testList)   { Console.WriteLine("-> " + x.GetName()); }
          Console.WriteLine("resultList has: " + resultList.Count +" elements");
          foreach (Client x in resultList) { Console.WriteLine("-> " + x.GetName()); }

          CollectionAssert.AreEqual(testList,resultList);
        }



  }
}
