using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdoriRails.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

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
            User us = new User("Roel", "roelvdboom@gmail.com", Role.Administrator);
            ms.AddUser(us);

            if (ms.GetAllUsers().Contains(us))
            {
                Assert.AreEqual(1,1);
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
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            Assert.Fail();
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
            Assert.Fail();
        }
        #endregion
    }
}