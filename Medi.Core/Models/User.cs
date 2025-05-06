using System.Text.RegularExpressions;

namespace Medi.Core.Models
{
    public class User
    {

        public User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }
        public Guid Id { get; set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

        // связи
        public List<Course> Courses { get; private set; }
        public List<Medicine> Medicines { get; private set; }

        public static User Create(Guid id, string userName, string passwordHash, string email)
        {
            var user = new User(id, userName, passwordHash, email);

            return (user);
        }

    }
}
