﻿using OdoriRails.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OdoriRails.DAL
{
    public class TramContext : ITramContext
    {
        public void AddTram(Tram tram)
        {
            var query = new SqlCommand("INSERT INTO Tram (TramPk,Line,Status,ModelFk,DriverFk,Location,DepartureTime), VALUES(@id,@line,@status,@model,@driver,@location,@departure)");
            query.Parameters.AddWithValue("@id", tram.Number);
            query.Parameters.AddWithValue("@line", tram.Line);
            query.Parameters.AddWithValue("@status", (int)tram.Status);
            query.Parameters.AddWithValue("@model", (int)tram.Model);
            query.Parameters.AddWithValue("@location", (int)tram.Location);
            query.Parameters.AddWithValue("@departure", tram.DepartureTime);
            if (tram.Driver != null) query.Parameters.AddWithValue("@driver", Database.GetUserId(tram.Driver.Username));
            else query.Parameters.AddWithValue("@driver", DBNull.Value);

            Database.GetData(query);
        }

        public void RemoveTram(Tram tram)
        {
            Database.GetData(new SqlCommand($"DELETE FROM Tram WHERE TramPk = {tram.Number}"));
        }

        public List<Tram> GetAllTrams()
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand("SELECT * FROM Tram")), Database.CreateTram);
        }

        public Tram GetTramByDriver(User driver)
        {
            var data = Database.GetData(new SqlCommand($"SELECT * FROM Tram WHERE DriverFk = {driver.Id}"));
            if (data.Rows.Count > 0) return Database.CreateTram(data.Rows[0]);
            return null;
        }

        public List<Tram> GetAllTramsWithStatus(TramStatus status)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM Tram WHERE Status = {(int)status}")), Database.CreateTram);
        }

        public List<Tram> GetAllTramsWithLocation(TramLocation location)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM Tram WHERE Status = {(int)location}")), Database.CreateTram);
        }
    }
}