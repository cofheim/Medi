using Infrastructure;
using Medi.Core.Models;
using Medi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Medi.Application.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvder;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) 
        {
            userRepository = _userRepository;
            passwordHasher = _passwordHasher;
            jwtProvider = _jwtProvder;
        }
        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, email, hashedPassword);

            await _userRepository.Add(user);
        }

        public async Task<string> Login (string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);
            
            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvder.GenerateToken(user);

            return token;
        }
    }
}
