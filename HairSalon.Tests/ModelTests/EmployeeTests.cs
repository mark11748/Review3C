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



   }
}
