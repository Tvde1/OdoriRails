using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails.DAL.Tests
{
    [TestClass()]
    public class MssqlDatabaseContextTests
    {
        MssqlDatabaseContext ms = new MssqlDatabaseContext();
        #region User
        [TestMethod()]
        public void AddUserTest()
        {
            User us = new User(1, "Roel", "roelvdboom", "roelvdboom@gmail.com", "roel1234", Role.Administrator, "");
            ms.AddUser(us);

            if (ms.GetAllUsers().Contains(us))
            {
                Assert.AreEqual(true, true);
            }
            else
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveUserTest()
        {
            User us = new User(1, "Roel", "roelvdboom", "roelvdboom@gmail.com", "roel1234", Role.Administrator, "");
            ms.AddUser(us);

            if (ms.GetAllUsers().Contains(us))
            {
                ms.RemoveUser(us);
                if (!ms.GetAllUsers().Contains(us))
                {
                    Assert.AreEqual(true, true);
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetUserTest()
        {
            Assert.AreEqual(ms.GetUser(1).Password, "12345");
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            User us = ms.GetUser(1);
            User us2 = new User(us.Id, us.Name, us.Username, us.Email, us.Password, Role.Logistic, us.ManagerUsername);
            ms.UpdateUser(us);

            Assert.AreEqual(us2, ms.GetUser(1));

            User us3 = ms.GetUser(1);
            User us4 = new User(us3.Id, us3.Name, us3.Username, us3.Email, us3.Password, Role.Administrator, us3.ManagerUsername);
            ms.UpdateUser(us3);
        }

        [TestMethod()]
        public void GetUserTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllUsersWithRoleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserIdTest()
        {
            Assert.Fail();
        }
        #endregion

        #region Tram
        [TestMethod()]
        public void AddTramTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTramTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTramTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTramsOnATrackTest()
        {
            Assert.Fail();
        }
        #endregion

        #region Track and Sector
        [TestMethod()]
        public void GetTracksAndSectorsTest()
        {
            Assert.Fail();
        }
        #endregion

        #region Service
        [TestMethod()]
        public void GetAllServicesFromUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddCleaningTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddRepairTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllRepairsWithoutUsersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllCleansWithoutUsersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteServiceTest()
        {
            Assert.Fail();
        }
        #endregion

        #region Login
        [TestMethod()]
        public void ValidateUsernameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MatchUsernameAndPasswordTest()
        {
            User U1 = new User(404, "Tester1", "Test", "Test@test.com","TEST",Role.Administrator,"Test");

        }
        #endregion
    }
}