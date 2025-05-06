using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medi.Core.Models;

namespace Medi.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Roles Role { get ; set; } = Roles.Client;
        public UserStatus Status { get; set; } = UserStatus.Active;

        public List<CourseEntity> Courses { get; private set; }
        public List<MedicineEntity> Medicines { get; private set; }
    }
}
