﻿using System;
using System.Collections.Generic;
using System.Linq;
using Beheersysteem.DAL.Repository;
using LoginSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdoriRails.BaseClasses;

namespace OdoriRailsTests1
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
            User user = loginRepository.GetUser("Driver");

            Assert.AreEqual(user.Email, "Driver@Remise.nl");
        }
    }

    [TestClass()]
    public class LogisticRepositoryTest
    {
        LogisticRepository logisticRepository = new LogisticRepository();

        [TestMethod()]
        public void AddRemoveTram()
        {
            bool working = false;
            User user = new User(1, "Driver", "Driver", "Driver@Remise.nl", "123", Role.Driver, "HeadClean");
            Tram tram = new Tram(1, TramStatus.Idle, 5, user, TramModel.TwaalfG, TramLocation.In, DateTime.Now);

            logisticRepository.AddTram(tram);

            Assert.IsTrue(logisticRepository.GetAllTrams().Any());
            foreach (Tram itemTram in logisticRepository.GetAllTrams())
            {
                if (itemTram.Number == 1)
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
                if (itemTram.Number == 1)
                {
                    working = true;
                }
            }
            Assert.IsFalse(working);
        }

        [TestMethod()]
        public void GetTram()
        {
            Tram tram = logisticRepository.GetTram(809);

            Assert.AreEqual(tram.Model, TramModel.Opleidingstram);
        }

        [TestMethod()]
        public void GetTramByDriver()
        {
            User user = new User(7, "Driver", "Driver", "Driver@Remise.nl", "123", Role.Driver, "HeadClean");
            Tram tram = logisticRepository.GetTramByDriver(user);

            Assert.AreEqual(tram.Number, 823);
        }

        [TestMethod()]
        public void HadBigMaintenanceTest()
        {
            User user = new User(7, "Driver", "Driver", "Driver@Remise.nl", "123", Role.Driver, "HeadClean");
            Tram tram = new Tram(1, TramStatus.Idle, 5, user, TramModel.TwaalfG, TramLocation.In, DateTime.Now);
            Repair repair = new Repair(1, DateTime.Parse("18-1-2016"), DateTime.Now, RepairType.Maintenance, "Big Planned Maintenance", "-", new List<User>(), 1);

            logisticRepository.AddTram(tram);
            repair = logisticRepository.AddRepair(repair);

            Assert.IsFalse(logisticRepository.HadBigMaintenance(tram));

            logisticRepository.DeleteService(repair);
            logisticRepository.RemoveTram(tram);
        }

        [TestMethod()]
        public void GetAllRepairsFromUser()
        {
            User user = logisticRepository.GetUser("Driver");
            Tram tram = new Tram(1, TramStatus.Idle, 5, user, TramModel.TwaalfG, TramLocation.In, DateTime.Now);

            List<User> listUsers = new List<User>();
            listUsers.Add(user);

            Repair repair = new Repair(1, DateTime.Parse("18-1-2016"), DateTime.Now, RepairType.Maintenance, "Big Planned Maintenance", "-", listUsers, 1);

            logisticRepository.AddTram(tram);
            repair = logisticRepository.AddRepair(repair);

            bool working = false;

            foreach (Repair itemRepair in logisticRepository.GetAllRepairsFromUser(user))
            {
                if (itemRepair.Id == repair.Id)
                {
                    working = true;
                }
            }

            Assert.IsTrue(working);

            logisticRepository.DeleteService(repair);
            logisticRepository.RemoveTram(tram);
        }
    }
}