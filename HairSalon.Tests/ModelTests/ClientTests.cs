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
        public void GetAll_Client_Empty()
        {
          Client clientA = new Client("bob");
          Client clientB = new Client("smith");

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
