using Medi.Core.Models;

namespace Medi.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
    }
}