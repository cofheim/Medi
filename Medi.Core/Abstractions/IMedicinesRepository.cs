using Medi.Core.Models;

namespace Medi.DataAccess.Repositories
{
    public interface IMedicinesRepository
    {
        Task<Guid> Create(Medicine medicine);
        Task<Guid> Delete(Guid id);
        Task<List<Medicine>> Get();
        Task<Guid> Update(Guid id, string name, string description, DateTime startDate, DateTime endDate);
    }
}