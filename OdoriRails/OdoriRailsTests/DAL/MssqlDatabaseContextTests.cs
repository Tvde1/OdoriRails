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
            us = ms.AddUser(us);

            bool working = false;
            foreach (User user in ms.GetAllUsers())
            {
                if (user.Username == us.Username)
                {
                    working = true;
                    ms.RemoveUser(user);
                }
            }
            Assert.IsTrue(working);

            

        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            ms.GetAllUsers();
        }

        [TestMethod()]
        public void RemoveUserTest()
        {
            User us = new User(1, "Roel", "roelvdboom", "roelvdboom@gmail.com", "roel1234", Role.Administrator, "");
            ms.AddUser(us);

            bool working = false;

            foreach (User user in ms.GetAllUsers())
            {
                if (user.Username == us.Username)
                {
                    working = true;
                    ms.RemoveUser(user);
                }
            }
            Assert.IsTrue(working);
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
            ms.UpdateUser(us2);

            bool working = false;

            foreach (User user in ms.GetAllUsers())
            {
                if (user.Username == us2.Username && user.Role == Role.Logistic)
                {
                    working = true;

                    User us3 = ms.GetUser(1);
                    User us4 = new User(us3.Id, us3.Name, us3.Username, us3.Email, us3.Password, Role.Administrator, us3.ManagerUsername);
                    ms.UpdateUser(us3);
                }
            }

            Assert.IsTrue(working);
        }

        [TestMethod()]
        public void GetAllUsersWithRoleTest()
        {
            User us1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); ms.AddUser(us1);
            User us2 = new User(405, "Tester2", "Test2", "Test@test.com", "TEST2", Role.HeadEngineer, "Test2"); ms.AddUser(us2);

            Assert.AreEqual(true, ms.GetAllUsersWithRole(Role.Administrator).Contains(us1));
            Assert.AreEqual(false, ms.GetAllUsersWithRole(Role.Administrator).Contains(us2));

            // clear test data from db.
            ms.RemoveUser(us1);
            ms.RemoveUser(us2);
        }

        [TestMethod()]
        public void GetUserIdTest()
        {
            User us1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); ms.AddUser(us1);
            Assert.AreEqual(us1.Id, ms.GetUserId(us1.Username));

            // clear test data from db.
            ms.RemoveUser(us1);
        }
        #endregion

        #region Tram
        [TestMethod()]
        public void AddTramTest()
        {
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); U1 = ms.AddUser(U1);
            Tram Tr1 = new Tram(404, TramStatus.Idle, 1, U1, Model.Classic, TramLocation.In, DateTime.Now); ms.AddTram(Tr1);
            Assert.AreEqual(Tr1, ms.GetTram(Tr1.Number));

            // clear test data from db.
            ms.RemoveUser(U1);
            ms.RemoveTram(Tr1);
        }

        [TestMethod()]
        public void RemoveTramTest()
        {
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); U1 = ms.AddUser(U1);
            Tram Tr1 = new Tram(404, TramStatus.Idle, 1, U1, Model.Classic,TramLocation.In, DateTime.Now); ms.AddTram(Tr1);
            ms.RemoveTram(Tr1);

            try
            {
                ms.GetTram(Tr1.Number);
                Assert.Fail();
            }
            catch
            {
                Assert.AreEqual(1, 1);
            }


            // clear test data from db.
            ms.RemoveUser(U1);
            ms.RemoveTram(Tr1);
        }

        [TestMethod()]
        public void GetTramTest()
        {
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); U1 = ms.AddUser(U1);
            Tram Tr1 = new Tram(404, TramStatus.Idle, 1, U1, Model.Classic,TramLocation.In,DateTime.Now); ms.AddTram(Tr1);
            Assert.AreEqual(Tr1.Number, ms.GetTram(Tr1.Number));

            // clear test data from db.
            ms.RemoveUser(U1);
            ms.RemoveTram(Tr1);
        }
        #endregion

        #region Track and Sector
        [TestMethod()]
        public void GetTracksAndSectorsTest()
        {
            // op het moment van maken is er nog geen methode om een track toe tevoegen aan de db.
            //Track tk1 = new Track(1000, 404, TrackType.Normal);
            Assert.Fail();
        }
        #endregion

        #region Service
        [TestMethod()]
        public void GetAllServicesFromUserTest()
        {
            List<User> users = new List<User>();
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); users.Add(U1); U1 = ms.AddUser(U1);
            Cleaning Cl1 = new Cleaning(1, DateTime.Now, DateTime.Now, CleaningSize.Big, "test", users, 1); Cl1 = ms.AddCleaning(Cl1);
            Assert.AreEqual(true, ms.GetAllCleansFromUser(U1).Contains(Cl1));

            //Removing testdata from db.
            ms.RemoveUser(U1);
            ms.DeleteService(Cl1);
        }

        [TestMethod()]
        public void AddCleaningTest()
        {
            // these two methodes have to be tested together
            List<User> users = new List<User>();
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); users.Add(U1); U1 = ms.AddUser(U1);
            Cleaning Cl1 = new Cleaning(1, DateTime.Now, DateTime.Now, CleaningSize.Big, "test", users, 1); Cl1 = ms.AddCleaning(Cl1);
            Assert.AreEqual(true, ms.GetAllCleansWithoutUsers().Contains(Cl1));

            //Removing testdata from db.
            ms.RemoveUser(U1);
            ms.DeleteService(Cl1);
        }

        [TestMethod()]
        public void AddRepairTest()
        {
            // These two methodes have to be tested together.
            List<User> users = new List<User>();
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); users.Add(U1); U1 = ms.AddUser(U1);
            Repair R1 = new Repair(1, DateTime.Now, DateTime.Now, RepairType.Repair, "Test1", "test2", users, 1); R1 = ms.AddRepair(R1);
            Assert.AreEqual(true, ms.GetAllRepairsWithoutUsers().Contains(R1));

            //Removing testdata from db.
            ms.RemoveUser(U1);
            ms.DeleteService(R1);

        }

       

        

        [TestMethod()]
        public void EditServiceTest()
        {
            // De enige propertie van service die geset kan worden is id , en deze wordt overschreven door de database.
            // En deze methode gebruikt de id om de services te vergelijken.

            //List<User> users = new List<User>();
            //User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); users.Add(U1); U1 = ms.AddUser(U1);
            // Repair R1 = new Repair(1, DateTime.Now, DateTime.Now, RepairType.Repair, "Test1", "test2", users, 1); R1 = ms.AddRepair(R1);
            //R1.SetId(101);
            //ms.EditService(R1);
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteServiceTest()
        {
            List<User> users = new List<User>();
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); users.Add(U1); U1 = ms.AddUser(U1);
            Repair R1 = new Repair(1, DateTime.Now, DateTime.Now, RepairType.Repair, "Test1", "test2", users, 1); R1 = ms.AddRepair(R1);
            ms.DeleteService(R1);
            Assert.AreEqual(false, ms.GetAllRepairsWithoutUsers().Contains(R1));

            //Removing testdata from db.
            ms.RemoveUser(U1);
        }
        #endregion

        #region Login
        [TestMethod()]
        public void ValidateUsernameTest()
        {
            List<User> users = new List<User>();
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); U1 = ms.AddUser(U1); users.Add(U1);
            Assert.AreEqual(true, ms.ValidateUsername(U1.Username));

            //Removing testdata from db.
            ms.RemoveUser(U1);
        }

        [TestMethod()]
        public void MatchUsernameAndPasswordTest()
        {
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test");
            ms.AddUser(U1);
            Assert.AreEqual(true, ms.MatchUsernameAndPassword(U1.Username, U1.Password));

            //Removing testdata from db.
            ms.RemoveUser(U1);

        }
        #endregion
    }
}