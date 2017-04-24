using System.Windows.Forms;
using OdoriRails.DAL;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Repository;

namespace In_Uitrit_Systeem
{
    public class Logic
    {
        public InUitRitTram Tram { get; private set; }
        private InUitrijRepository _inUitrijRepository = new InUitrijRepository();

        public Logic(User driver)
        {
            var tempTram = _inUitrijRepository.GetTramByDriver(driver);
            Tram = tempTram == null ? null : InUitRitTram.ToInUitRitTram(tempTram);
        }

        public string GetAssingedTramLocation()
        {
            Sector sector = _inUitrijRepository.GetAssignedSector(Tram);
            return string.Format("Track: {0}, Sector: {1}", sector.TrackNumber, sector.Number);
        }

        public void AddRepair(string defect)
        {
            var repair = new Repair(Tram.Number, defect);
            _inUitrijRepository.AddRepair(repair);
        }

        public void AddCleaning()
        {
            var cleaning = new Cleaning(Tram.Number);
            _inUitrijRepository.AddCleaning(cleaning);
        }

        public void UpdateTram()
        {
            _inUitrijRepository.EditTram(Tram);
        }

        public void FetchTramUpdates()
        {
            Tram = InUitRitTram.ToInUitRitTram(_inUitrijRepository.FetchTram(Tram));
        }
    }
}
