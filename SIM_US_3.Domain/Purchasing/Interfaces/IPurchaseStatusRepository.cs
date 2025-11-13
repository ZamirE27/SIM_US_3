using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.Purchasing.Aggregates;

namespace SIM_US_3.Domain.Purchasing.Interfaces;

public interface IPurchaseStatusRepository : IRepository<PurchaseStatus>
{
    Task<PurchaseStatus?> GetByNameAsync(string name);
}