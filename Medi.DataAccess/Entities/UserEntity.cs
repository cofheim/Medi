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

        public List<CourseEntity> Courses { get; private set; }
        public List<MedicineEntity> Medicines { get; private set; }
    }
}
