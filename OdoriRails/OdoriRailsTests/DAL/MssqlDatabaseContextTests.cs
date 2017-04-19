using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdoriRails.BaseClasses;
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
            User us = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test");
            ms.AddUser(us);

            if (ms.GetAllUsers().Contains(us))
            {
                Assert.AreEqual(1,1);
            }
            else
            {
                Assert.Fail();
            }

            // clear test data from db.
            ms.RemoveUser(us);
          
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            User us1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); ms.AddUser(us1);
            User us2 = new User(405, "Tester2", "Test2", "Test@test.com", "TEST2", Role.HeadEngineer, "Test2"); ms.AddUser(us2);

            Assert.AreEqual(true, ms.GetAllUsers().Contains(us1) && ms.GetAllUsers().Contains(us2));

            // clear test data from db.
            ms.RemoveUser(us1);
            ms.RemoveUser(us2);
        }

        [TestMethod()]
        public void RemoveUserTest()
        {
            User us1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); ms.AddUser(us1);
            ms.RemoveUser(us1);
            Assert.AreEqual(false, ms.GetAllUsers().Contains(us1));

            // clear test data from db.
            ms.RemoveUser(us1);
        }

        [TestMethod()]
        public void GetUserTest()
        {
            User us1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); ms.AddUser(us1);
            Assert.AreEqual(us1.Name, ms.GetUser(1).Name);

            // clear test data from db.
            ms.RemoveUser(us1);
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            // De enige propertie van User die geset kan worden is id , en deze wordt overschreven door de database.
            // En deze methode gebruikt de id om de Users te vergelijken.

            //User us1 = new User("Roel", "roelvdboom@gmail.com", Role.Administrator); ms.AddUser(us1);
            //us1.SetId(101);
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
            Tram Tr1 = new Tram(404, TramStatus.Idle, 1, U1, Model.Classic);  ms.AddTram(Tr1);
            Assert.AreEqual(true, ms.GetAllTramsOnATrack().Contains(Tr1));

            // clear test data from db.
            ms.RemoveUser(U1);
            ms.RemoveTram(Tr1);

        }

        [TestMethod()]
        public void RemoveTramTest()
        {
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); U1 = ms.AddUser(U1);
            Tram Tr1 = new Tram(404, TramStatus.Idle, 1, U1, Model.Classic); ms.AddTram(Tr1);
            ms.RemoveTram(Tr1);
            Assert.AreEqual(false, ms.GetAllTramsOnATrack().Contains(Tr1));

            // clear test data from db.
            ms.RemoveUser(U1);
            ms.RemoveTram(Tr1);
        }

        [TestMethod()]
        public void GetTramTest()
        {

            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); U1 = ms.AddUser(U1);
            Tram Tr1 = new Tram(404, TramStatus.Idle, 1, U1, Model.Classic); ms.AddTram(Tr1);
            Assert.AreEqual(Tr1.Number, ms.GetTram(Tr1.Number));

            // clear test data from db.
            ms.RemoveUser(U1);
            ms.RemoveTram(Tr1);
        }

        [TestMethod()]
        public void GetAllTramsOnATrackTest()
        {
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); U1 = ms.AddUser(U1);
            Tram Tr1 = new Tram(404, TramStatus.Maintenance, 1, U1, Model.Classic); ms.AddTram(Tr1);
            Tram Tr2 = new Tram(405, TramStatus.Idle, 1, U1, Model.Classic); ms.AddTram(Tr2);
            Assert.AreEqual(true, ms.GetAllTramsOnATrack().Contains(Tr1) && ms.GetAllTramsOnATrack().Contains(Tr2));

            // clear test data from db.
            ms.RemoveUser(U1);
            ms.RemoveTram(Tr1);
            ms.RemoveTram(Tr2);

        }
        #endregion

        #region Track and Sector
        [TestMethod()]
        public void GetTracksAndSectorsTest()
        {
            // op het moment van maken is er nog geen methode om een track toe tevoegen aan de db.
            //Track tk1 = new Track(1000, 404, TrackType.Normal);
            
        }
        #endregion

        #region Service
        [TestMethod()]
        public void GetAllServicesFromUserTest()
        {
            List<User> users = new List<User>();
            User U1 = new User(404, "Tester1", "Test", "Test@test.com", "TEST", Role.Administrator, "Test"); users.Add(U1); U1 = ms.AddUser(U1);
            Cleaning Cl1 = new Cleaning(1,DateTime.Now,DateTime.Now,CleaningSize.Big,"test",users,1); Cl1 = ms.AddCleaning(Cl1);
            Assert.AreEqual(true, ms.GetAllServicesFromUser(U1).Contains(Cl1));

            //Removing testdata from db.
            ms.RemoveUser(U1);
            ms.DeleteService(Cl1);

            


        }

        [TestMethod()]
        public void AddCleaningTestAndGetAllCleansWithoutUsersTest()
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
        public void AddRepairTestAndGetAllRepairswithoutUsersTest()
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
            User U1 = new User(404, "Tester1", "Test", "Test@test.com","TEST",Role.Administrator,"Test");
            ms.AddUser(U1);
            Assert.AreEqual(true, ms.MatchUsernameAndPassword(U1.Username, U1.Password));

            //Removing testdata from db.
            ms.RemoveUser(U1);
        }
        #endregion
    }
}