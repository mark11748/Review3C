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
        public void GetAll_Client_Empty()
        {
          
        }



  }
}
