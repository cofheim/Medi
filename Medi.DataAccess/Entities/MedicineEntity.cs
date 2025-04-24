using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medi.Core.Models;

namespace Medi.DataAccess.Entities
{
    public class MedicineEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MedicineForm Form { get; set; } = MedicineForm.Other;
        public IntakeFrequency Frequency { get; set; } = IntakeFrequency.Custom;
        public Status Status { get; set; } = Status.Planned;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
    }
}
