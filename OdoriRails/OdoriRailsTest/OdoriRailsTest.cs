using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdoriRails.DAL.Repository;
using OdoriRails.BaseClasses;

namespace OdoriRailsTest
{
    [TestClass]
    public class OdoriRailsTest
    {
        

        [TestMethod]
        public void ValidateUsernameTest()
        {
            LoginRepository loginRepository = new LoginRepository();
            Assert.IsTrue(loginRepository.ValidateUsername("Admin"));
        }

        public void MatchUsernameAndPasswordTest()
        {
            LoginRepository loginRepository = new LoginRepository();
            Assert.IsTrue(loginRepository.MatchUsernameAndPassword("Admin","123"));
        }

        public void GetUserTest()
        {
            LoginRepository loginRepository = new LoginRepository();
            User us = loginRepository.GetUser("Admin");

            Assert.AreEqual(us.Email, "Admin@Remise.nl");
        }
    }
}
