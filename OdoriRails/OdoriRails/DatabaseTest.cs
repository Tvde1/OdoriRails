﻿using System.Linq;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace OdoriRails
{
    internal static class DatabaseTest
    {
        public static void OnLoad()
        {
            MessageBox.Show(GetAdminName());
        }

        private static string GetAdminName()
        {
            //IBeheerDatabaseAdapter databaseConnector = new MssqlDatabaseContext();
            //var admin = databaseConnector.GetUser("admin");

            //User user = new User(4, "Mark Rutte", "markiee1", "mark@hotmail.com", "ikwordgeilvanwilders", Role.Logistic, "admin");
            //return databaseConnector.AddUser(user).ToString();

            // ReSharper disable once UnusedVariable
            //var users = databaseConnector.GetAllUsers();
            // ReSharper disable once UnusedVariable
            //var schoonmakersTest = users.Where(x => x.Role == Role.Cleaner).ToList();

            return null;
        }
    }
}