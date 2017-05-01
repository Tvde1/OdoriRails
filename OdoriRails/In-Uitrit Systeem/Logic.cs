using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public class Logic
    {
        public InUitRitTram Tram { get; private set; }
        private InUitrijRepository _inUitrijRepository = new InUitrijRepository();
        private User driver;

        public Logic(User driver)
        {
            this.driver = driver;
            LoadTram();
        }

        public void LoadTram()
        {
            var tempTram = _inUitrijRepository.GetTramByDriver(driver);
            Tram = tempTram == null ? null : InUitRitTram.ToInUitRitTram(tempTram);
        }

        public string GetAssingedTramLocation()
        {
            Sector sector = _inUitrijRepository.GetAssignedSector(Tram);
            if (sector != null)
            {
                return string.Format("Track: {0}, Sector: {1}", sector.TrackNumber, sector.Number);
            }
            else
            {
                return null;
            }
        }

        public void AddRepair(string defect)
        {
            var repair = new Repair(Tram.Number, defect);
            _inUitrijRepository.AddRepair(repair);
        }

        public void AddCleaning(string comment)
        {
            var cleaning = new Cleaning(Tram.Number, comment);
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
