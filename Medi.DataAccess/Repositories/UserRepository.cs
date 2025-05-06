using Medi.Core.Models;
using Medi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Medi.Core.Abstractions;

namespace Medi.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MediDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(MediDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add (User user)
        {
            var userEntity = new UserEntity() 
            { 
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Role = user.Role,
                Status = user.Status
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            return _mapper.Map<UserEntity, User>(userEntity);
        }
    }
}
