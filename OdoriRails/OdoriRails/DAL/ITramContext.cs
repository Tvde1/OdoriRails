using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
