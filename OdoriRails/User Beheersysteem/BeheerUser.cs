using OdoriRails.BaseClasses;

namespace User_Beheersysteem
{
    class BeheerUser : User
    {
        public BeheerUser(int id, string name, string username, string email, string password, Role role, string managedByUsername) : base(id, name, username, email, password, role, managedByUsername)
        { }
    }
}
