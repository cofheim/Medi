using System.Text.RegularExpressions;

namespace Medi.Core.Models
{
    public enum Roles 
    {
        Admin,
        Client
    }
    public enum UserStatus
    {
        Active,
        Inactive,
        Blocked
    }

    public class User
    {
        const int MAX_NAME_LENGTH = 50;
        const int MAX_EMAIL_LENGTH = 100;

        public User(Guid id, string userName, string passwordHash, string email, DateTime createdAt, Roles role, UserStatus status)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            CreatedAt = createdAt;
            Role = role;
            Status = status;
        }
        public Guid Id { get; set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; } 
        public string Email { get; private set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public Roles Role { get; private set; } = Roles.Client;
        public UserStatus Status { get; private set; } = UserStatus.Active;

        // связи
        public List<Course> Courses { get; private set; }
        public List<Medicine> Medicines { get; private set; }

        public static (User User, string Error) Create(Guid id, string userName, string passwordHash, string email, DateTime createdAt, Roles role, UserStatus status)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(userName) || userName.Length > MAX_NAME_LENGTH)
                error = $"Name cannot be empty or longer than {MAX_NAME_LENGTH} symbols";

            if (string.IsNullOrEmpty(email))
                error = "Email cannot be empty";
            else if (email.Length > MAX_EMAIL_LENGTH)
                error = $"Email cannot be longer than {MAX_EMAIL_LENGTH} symbols";


            var user = new User(id, userName, passwordHash, email, createdAt, role, status);

            return (user, error);

        }

    }
}
