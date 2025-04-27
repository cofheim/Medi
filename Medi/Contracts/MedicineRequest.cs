using Medi.Core.Models;

namespace Medi.API.Contracts
{
    public record MedicineRequest (string name, string description, MedicineForm form);
}
