namespace Medi.API.Contracts
{
    public record MedicineResponse (Guid id, string name, string description, DateTime startDate, DateTime endDate);
}
