using System.Threading.Tasks;

public interface IUserRepository
{
    bool Authenticate(string username, string password);
}