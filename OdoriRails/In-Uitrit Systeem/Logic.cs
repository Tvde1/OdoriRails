using System.Windows.Forms;
using OdoriRails.DAL;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public class Logic
    {
        public InUitRitTram Tram { get; private set; }
        private IServiceContext _serviceContext = new ServiceContext();
        private ITramContext _tramContext = new TramContext();

        public Logic(User driver)
        {
            var tempTram = _tramContext.GetTramByDriver(driver);
            Tram = tempTram == null ? null : InUitRitTram.ToTram(tempTram);
        }

        public void AddRepair(string defect)
        {
            var repair = new Repair(Tram.Number, defect);
            _serviceContext.AddRepair(repair);
        }

        public void AddCleaning()
        {
            var cleaning = new Cleaning(Tram.Number);
            _serviceContext.AddCleaning(cleaning);
        }
    }
}
