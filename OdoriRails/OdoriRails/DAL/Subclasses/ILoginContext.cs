namespace OdoriRails.DAL.Subclasses
{
    public interface ILoginContext
    {
        bool ValidateUsername(string username);

        bool MatchUsernameAndPassword(string username, string password);
    }
}
