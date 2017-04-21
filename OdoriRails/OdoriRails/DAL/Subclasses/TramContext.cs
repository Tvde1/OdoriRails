﻿using OdoriRails.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace OdoriRails.DAL.Subclasses
{
    public class TramContext : ITramContext
    {
        private static readonly UserContext UserContext = new UserContext();
        private static readonly TrackSectorContext TrackSectorContext = new TrackSectorContext();

        public Tram GetTram(int tramId)
        {
            return CreateTram(Database.GetData(new SqlCommand($"SELECT * FROM Tram WHERE TramPk = {tramId}")).Rows[0]);
        }

        public void AddTram(Tram tram)
        {
            var query = new SqlCommand("INSERT INTO Tram (TramPk,Line,Status,ModelFk,DriverFk,Location,DepartureTime), VALUES(@id,@line,@status,@model,@driver,@location,@departure)");
            query.Parameters.AddWithValue("@id", tram.Number);
            query.Parameters.AddWithValue("@line", tram.Line);
            query.Parameters.AddWithValue("@status", (int)tram.Status);
            query.Parameters.AddWithValue("@model", (int)tram.Model);
            query.Parameters.AddWithValue("@location", (int)tram.Location);
            query.Parameters.AddWithValue("@departure", tram.DepartureTime);
            if (tram.Driver != null) query.Parameters.AddWithValue("@driver", UserContext.GetUserId(tram.Driver.Username));
            else query.Parameters.AddWithValue("@driver", DBNull.Value);

            Database.GetData(query);
        }

        public void RemoveTram(Tram tram)
        {
            Database.GetData(new SqlCommand($"DELETE FROM Tram WHERE TramPk = {tram.Number}"));
        }

        public List<Tram> GetAllTrams()
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand("SELECT * FROM Tram")), CreateTram);
        }

        public Tram GetTramByDriver(User driver)
        {
            var data = Database.GetData(new SqlCommand($"SELECT * FROM Tram WHERE DriverFk = {driver.Id}"));
            if (data.Rows.Count > 0) return CreateTram(data.Rows[0]);
            return null;
        }

        public void EditTram(Tram tram)
        {
            //line status driver model remise location departure 
            var query = new SqlCommand("UPDATE Tram SET Line = @line, Status = @stat, DriverFk = @driver, ModelFk = @model, RemiseFk = @remis, Location = @loc, DepartureTime = @dep WHERE TramPk = @id");
            query.Parameters.AddWithValue("@line", tram.Line);
            query.Parameters.AddWithValue("@stat", (int) tram.Status);
            if (tram.Driver != null) query.Parameters.AddWithValue("@driver", UserContext.GetUserId(tram.Driver.Username));
            else query.Parameters.AddWithValue("@driver", DBNull.Value);
            query.Parameters.AddWithValue("@model", (int) tram.Model);
            query.Parameters.AddWithValue("@remis", 1); //TODO: Correct updaten.
            query.Parameters.AddWithValue("@loc", (int) tram.Location);
            query.Parameters.AddWithValue("@dep", tram.DepartureTime);
            query.Parameters.AddWithValue("@id", tram.Number);
            Database.GetData(query);
        }

        public List<Tram> GetAllTramsWithStatus(TramStatus status)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM Tram WHERE Status = {(int)status}")), CreateTram);
        }

        public List<Tram> GetAllTramsWithLocation(TramLocation location)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM Tram WHERE Status = {(int)location}")), CreateTram);
        }

        public Sector GetAssignedSector(Tram tram)
        {
            var data = Database.GetData(new SqlCommand($"SELECT * FROM Sector WHERE TramFk = {tram.Number}"));
            if (data.Rows.Count < 1) return null;
            return TrackSectorContext.CreateSector(data.Rows[0]);
        }

        private Tram CreateTram(DataRow row)
        {
            //Pk, Line, Status, Driver, Model, Remise, Location, Depart
            var array = row.ItemArray;
            var id = (int)array[0];
            var line = (int)array[1];
            var status = (TramStatus)array[2];
            var driver = array[3] == DBNull.Value ? null : UserContext.GetUser((int)array[3]);
            var model = (Model)array[4];
            var location = (TramLocation)array[6];
            DateTime? depart = null;
            if (array[7] != DBNull.Value) depart = (DateTime)array[7];

            return new Tram(id, status, line, driver, model, location, depart);
        }
    }
}
