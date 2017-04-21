namespace OdoriRails.DAL
{
    public interface ILoginContext
    {
        bool ValidateUsername(string username);

        bool MatchUsernameAndPassword(string username, string password);
    }
}
