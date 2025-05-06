using Medi.Core.Models;

namespace Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}