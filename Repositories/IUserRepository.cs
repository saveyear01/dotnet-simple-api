using AuthApi.Models;

namespace AuthApi.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        void Add(User user);
        void SaveChanges();
    }
}
