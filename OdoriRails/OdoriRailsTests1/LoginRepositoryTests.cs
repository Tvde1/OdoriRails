using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails.DAL.Repository.Tests
{
    [TestClass()]
    public class LoginRepositoryTest
    {
        LoginRepository loginRepository = new LoginRepository();

        [TestMethod()]
        public void ValidateUsernameTest()
        {
            Assert.IsTrue(loginRepository.ValidateUsername("Admin"));
        }

        [TestMethod()]
        public void MatchUsernameAndPassword()
        {
            Assert.IsTrue(loginRepository.MatchUsernameAndPassword("Admin", "123"));
        }

        [TestMethod()]
        public void GetUser()
        {
            User user = loginRepository.GetUser("Admin");

            Assert.AreEqual(user.Email, "Admin@Remise.nl");
        }
    }

    [TestClass()]
    public class LogisticRepositoryTest
    {
        LogisticRepository logisticRepository = new LogisticRepository();

        [TestMethod()]
        public void AddRemoveTram()
        {
            DateTime dateTimeNow = DateTime.Now;
            bool working = false;
            User user = new User(1, "Roel", "roelvdboom", "Roel@Remise.nl", "123", Role.Driver, "Admin");
            Tram tram = new Tram(1, TramStatus.Idle, 5, user, Model.TwaalfG, TramLocation.In, dateTimeNow);

            logisticRepository.AddTram(tram);

            Assert.IsTrue(logisticRepository.GetAllTrams().Any());
            foreach (Tram itemTram in logisticRepository.GetAllTrams())
            {
                if (itemTram.DepartureTime == dateTimeNow)
                {
                    working = true;
                    tram = itemTram;
                }
            }
            Assert.IsTrue(working);

            logisticRepository.RemoveTram(tram);

            working = false;
            foreach (Tram itemTram in logisticRepository.GetAllTrams())
            {
                if (itemTram.DepartureTime == dateTimeNow)
                {
                    working = true;
                }
            }
            Assert.IsFalse(working);
        }

        [TestMethod()]
        public void GetTram()
        {

        }

        [TestMethod()]
        public void GetTramByDriver()
        {

        }
    }
}