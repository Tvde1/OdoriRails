using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL.Subclasses
{
    public class ServiceContext : IServiceContext
    {
        private readonly UserContext _userContext = new UserContext();

        public List<Repair> GetAllRepairsFromUser(User user)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($@"
SELECT Repair.*
FROM Repair INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE ([User].UserPk = {user.Id})) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk")), CreateRepair);
        }

        public List<Cleaning> GetAllCleansFromUser(User user)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($@"
SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE ([User].UserPk ={user.Id})) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Clean.ServiceFk = derivedtbl_2.ServicePk")), CreateCleaning);
        }

        public List<Repair> GetAllRepairsWithoutUsers()
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand(@"SELECT Repair.*
FROM Repair INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Repair.ServiceFk = derivedtbl_1.ServicePk")), CreateRepair);
        }

        public List<Cleaning> GetAllCleansWithoutUsers()
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand(@"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Clean.ServiceFk = derivedtbl_1.ServicePk")), CreateCleaning);
        }

        public void EditService(Service service)
        {
            switch (service.GetType().Name)
            {
                case "Repair":
                    {
                        var repair = (Repair)service;
                        var repairQuery = new SqlCommand("UPDATE Repair SET Solution = @solution, Defect = @defect, Type = @type WHERE ServiceFk = @id");
                        repairQuery.Parameters.AddWithValue("@solution", repair.Solution);
                        repairQuery.Parameters.AddWithValue("@defect", repair.Defect);
                        repairQuery.Parameters.AddWithValue("@type", (int)repair.Type);
                        repairQuery.Parameters.AddWithValue("@id", service.Id);
                        Database.GetData(repairQuery);
                        break;
                    }
                case "Cleaning":
                    {
                        var cleaning = (Cleaning)service;
                        var cleaningQuery = new SqlCommand("UPDATE Clean SET Size = @size, Remarks = @remarks WHERE ServiceFk = @id");
                        cleaningQuery.Parameters.AddWithValue("@size", (int)cleaning.Size);
                        cleaningQuery.Parameters.AddWithValue("@remarks", cleaning.Comments);
                        cleaningQuery.Parameters.AddWithValue("@id", service.Id);
                        break;
                    }
            }
            var query = new SqlCommand("UPDATE Service SET StartDate = @startdate, EndDate = @enddate, TramFk = @tramfk WHERE ServicePk = @id");
            query.Parameters.AddWithValue("@startdate", service.StartDate);
            query.Parameters.AddWithValue("@enddate", service.EndDate);
            query.Parameters.AddWithValue("@tramfk", service.TramId);
            query.Parameters.AddWithValue("@id", service.Id);

            Database.GetData(query);
            SetUsersToServices(service.AssignedUsers, service);
        }

        public void DeleteService(Service service)
        {
            var query = new SqlCommand("DELETE FROM Service WHERE ServicePk = @id; DELETE FROM Clean WHERE ServiceFk = @id; DELETE FROM Repair WHERE ServiceFk = @id");
            query.Parameters.AddWithValue("@id", service.Id);
            Database.GetData(query);
        }

        public Cleaning AddCleaning(Cleaning cleaning)
        {
            var serviceQuery = new SqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT SCOPE_IDENTITY();");
            serviceQuery.Parameters.AddWithValue("@startdate", cleaning.StartDate);
            if (cleaning.EndDate == DateTime.MinValue) serviceQuery.Parameters.AddWithValue("@enddate", DBNull.Value);
            else serviceQuery.Parameters.AddWithValue("@enddate", cleaning.EndDate);
            serviceQuery.Parameters.AddWithValue("@tramfk", cleaning.TramId);

            var data = Database.GetData(serviceQuery);

            var cleaningQuery = new SqlCommand(@"INSERT INTO Clean (ServiceFk, Size, Remarks) VALUES (@id, @size, @remarks)");
            cleaningQuery.Parameters.AddWithValue("@id", data.Rows[0].ItemArray[0]);
            cleaningQuery.Parameters.AddWithValue("@size", (int)cleaning.Size);
            cleaningQuery.Parameters.AddWithValue("@remarks", cleaning.Comments ?? "");
            Database.GetData(cleaningQuery);

            SetUsersToServices(cleaning.AssignedUsers, cleaning);

            cleaning.SetId(Convert.ToInt32((decimal)data.Rows[0].ItemArray[0]));
            return cleaning;
        }

        public Repair AddRepair(Repair repair)
        {
            var serviceQuery = new SqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT SCOPE_IDENTITY();");
            serviceQuery.Parameters.AddWithValue("@startdate", repair.StartDate);
            if (repair.EndDate == DateTime.MinValue) serviceQuery.Parameters.AddWithValue("@enddate", DBNull.Value);
            else serviceQuery.Parameters.AddWithValue("@enddate", repair.EndDate);
            serviceQuery.Parameters.AddWithValue("@tramfk", repair.TramId);

            var data = Database.GetData(serviceQuery);

            var repairQuery = new SqlCommand(@"INSERT INTO Repair (ServiceFk, Solution, Defect, Type) VALUES (@id, @solution, @defect, @type)");
            repairQuery.Parameters.AddWithValue("@id", data.Rows[0].ItemArray[0]);
            repairQuery.Parameters.AddWithValue("@solution", repair.Solution ?? "");
            repairQuery.Parameters.AddWithValue("@defect", repair.Defect ?? "");
            repairQuery.Parameters.AddWithValue("@type", (int)repair.Type);
            Database.GetData(repairQuery);

            SetUsersToServices(repair.AssignedUsers, repair);

            repair.SetId(Convert.ToInt32((decimal)data.Rows[0].ItemArray[0]));
            return repair;
        }

        public List<Repair> GetAllRepairsFromTram(Tram tram)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM Repair WHERE TramFk = {tram.Number}")), CreateRepair);
        }

        public List<Cleaning> GetAllCeCleaningsFromTram(Tram tram)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM Cleaning WHERE TramFk = {tram.Number}")), CreateCleaning);
        }

        public bool HadBigMaintenance(Tram tram)
        {
            throw new NotImplementedException();
        }

        public bool HadSmallMaintenance(Tram tram)
        {
            throw new NotImplementedException();
        }


        private Cleaning CreateCleaning(DataRow row)
        {
            var array = row.ItemArray;
            var service = Database.GetData(new SqlCommand($"SELECT * FROM Service WHERE ServicePk = {(int)array[0]}")).Rows[0].ItemArray;

            var id = (int)service[0];
            var startDate = (DateTime)service[1];
            var endDate = service[2] == DBNull.Value ? DateTime.MinValue : (DateTime)service[2];
            var tramId = (int)service[3];

            var type = (CleaningSize)array[1];
            var comments = (string)array[2];
            var users = GetUsersInServiceById((int)service[0]);

            return new Cleaning(id, startDate, endDate, type, comments, users, tramId);
        }

        private Repair CreateRepair(DataRow row)
        {
            var array = row.ItemArray;
            var service = Database.GetData(new SqlCommand($"SELECT * FROM Service WHERE ServicePk = {(int)array[0]}")).Rows[0].ItemArray;

            var id = (int)service[0];
            var startDate = (DateTime)service[1];
            var endDate = service[2] == DBNull.Value ? DateTime.MinValue : (DateTime)service[2];
            var tramId = (int)service[3];

            var solution = (string)array[1];
            var defect = (string)array[2];
            var type = (RepairType)array[3];
            var users = GetUsersInServiceById((int)service[0]);

            return new Repair(id, startDate, endDate, type, defect, solution, users, tramId);
        }

        private List<User> GetUsersInServiceById(int serviceId)
        {
            var command = new SqlCommand($@"SELECT [User].*, Service.ServicePk
FROM Service INNER JOIN
ServiceUser ON Service.ServicePk = ServiceUser.ServiceCk INNER JOIN
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE (Service.ServicePk = {serviceId})");
            return Database.GenerateListWithFunction(Database.GetData(command), _userContext.CreateUser);
        }

        private static void SetUsersToServices(List<User> users, Service service)
        {
            if (users == null) return;
            foreach (DataRow dataRow in Database.GetData(new SqlCommand($"SELECT * FROM ServiceUser WHERE ServiceCk = {service.Id}")).Rows)
            {
                if (users.All(x => x.Id != (int)dataRow.ItemArray[0]))
                {
                    Database.GetData(new SqlCommand($"DELETE FROM ServiceUser WHERE ServiceCk = {service.Id} AND UserCk = {(int)dataRow.ItemArray[0]}"));
                }
            }

            foreach (var user in users)
            {
                if (Database.GetData(new SqlCommand($"SELECT * FROM ServiceUser WHERE UserCk = {user.Id} AND ServiceCk = {service.Id}")).Rows.Count < 1)
                {
                    Database.GetData(new SqlCommand($"INSERT INTO ServiceUser (ServiceCk, UserCk) VALUES ({service.Id},{user.Id})"));
                }
            }
        }
    }
}
