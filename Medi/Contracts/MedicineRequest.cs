namespace Medi.API.Contracts
{
    public record MedicineRequest (string name, string description, DateTime startDate, DateTime endDate);
}
