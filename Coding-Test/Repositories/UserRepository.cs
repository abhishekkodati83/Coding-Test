using System.Collections.Generic;
using System.Linq;
using Coding_Test.Models;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>()
    {
            new User
            {
                Id = 1, Username = "admin1@test.com", Password = "user1"
            },
            new User
            {
                Id = 2, Username = "admin2@test.com", Password = "user2"
            }
        };

    public bool Authenticate(string username, string password)
    {
        if (_users.SingleOrDefault(x => x.Username == username && x.Password == password) != null)
        {
            return true;
        }

        return false;
    }
}