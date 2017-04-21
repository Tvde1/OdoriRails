using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public interface ITramContext
    {
        void AddTram(Tram tram);

        void RemoveTram(Tram tram);

        List<Tram> GetAllTrams();

        Tram GetTramByDriver(User user);

        List<Tram> GetAllTramsWithStatus(TramStatus tramStatus);

        List<Tram> GetAllTramsWithLocation(TramLocation tramLocation);
    }
}
