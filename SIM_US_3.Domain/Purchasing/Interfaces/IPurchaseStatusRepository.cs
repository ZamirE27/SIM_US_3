using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IPurchaseStatusRepository : IRepository<PurchaseStatus>
{
    Task<PurchaseStatus?> GetByNameAsync(string name);
}