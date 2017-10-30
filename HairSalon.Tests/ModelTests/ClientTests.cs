// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using System.Collections.Generic;
// using System;
// using HairSalon.Models;
//
// namespace HairSalon.Tests
// {
//
//  [TestClass]
//  public class ClientTests : IDisposable
//  {
//     public ClientTests()
//     {
//        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mark_woodward_test;";
//     }
//       public void Dispose()
//         {
//           Console.WriteLine("***< DATABASE IS BEING CLEARED >***");
//           Stylist.DeleteAll();
//           Client.DeleteAll();
//         }
//         [TestMethod]
//         public void Save_Client()
//         {
//           Stylist Bob  = new Stylist("Bob");
//           Bob.Save();
//           Client  Alex = new Client ("Alex",Bob.GetId());
//           Alex.Save();
//
//           Assert.AreEqual(true,Alex.GetId()>0);
//         }
//         [TestMethod]
//         public void GetAll_Client_Empty()
//         {
//           List<Client> resultList = Client.GetAll();
//
//           Assert.AreEqual(true,resultList.Count == 0);
//         }
//         [TestMethod]
//         public void GetAll_Client_HasClients()
//         {
//           Stylist stylistA = new Stylist("anna");
//           stylistA.Save();
//           Client clientA = new Client("bob",stylistA.GetId());
//           clientA.Save();
//           Client clientB = new Client("smith",stylistA.GetId());
//           clientB.Save();
//
//           List<Client> testList   = new List<Client>{clientA,clientB};
//           List<Client> resultList = Client.GetAll();
//
//           Console.WriteLine("testList   has: " + testList.Count   +" elements");
//           foreach (Client x in testList)   { Console.WriteLine("-> " + x.GetName()); }
//           Console.WriteLine("resultList has: " + resultList.Count +" elements");
//           foreach (Client x in resultList) { Console.WriteLine("-> " + x.GetName()); }
//
//           CollectionAssert.AreEqual(testList,resultList);
//         }
//         [TestMethod]
//         public void Delete_DeleteOneClient_NoEntries()
//         {
//           List<Client> testList = Client.GetAll();
//           Client.Delete(1);
//           List<Client> resultList = Client.GetAll();
//           CollectionAssert.AreEqual(testList,resultList);
//         }
//         [TestMethod]
//         public void Delete_DeleteOneClient_HasEntries()
//         {
//           Stylist stylistA = new Stylist("anna");
//           stylistA.Save();
//           Client clientA = new Client("bob",stylistA.GetId());
//           clientA.Save();
//           Client clientB = new Client("smith",stylistA.GetId());
//           clientB.Save();
//
//           List<Client> testList = Client.GetAll();
//           Console.WriteLine("testList   has: " + testList.Count   +" elements");
//           foreach (Client x in testList)   { Console.WriteLine("-> " + x.GetName()); }
//
//           Client.Delete(clientA.GetId());
//
//           List<Client> resultList = Client.GetAll();
//           Console.WriteLine("resultList has: " + resultList.Count +" elements");
//           foreach (Client x in resultList) { Console.WriteLine("-> " + x.GetName()); }
//
//           Assert.AreEqual(true, testList.Count == resultList.Count+1);
//         }
//         [TestMethod]
//         public void Update_UpdatesClientNameAndStylistId()
//         {
//           Stylist stylistA = new Stylist("Anna");
//           stylistA.Save();
//           Stylist stylistB = new Stylist("Julia");
//           stylistB.Save();
//           Client billy = new Client("Billy",stylistA.GetId());
//           billy.Save();
//
//           billy.Update("Bill",stylistB.GetId());
//           Console.WriteLine("instance: "+billy.GetName()+" : "+billy.GetId());
//           Console.WriteLine("record  : "+Client.GetAll()[billy.GetId()-1].GetName()+" : "+Client.GetAll()[billy.GetId()-1].GetId());
//
//           Assert.AreEqual(billy, Client.GetAll()[billy.GetId()-1]);
//
//         }
//
//
//
//   }
// }
