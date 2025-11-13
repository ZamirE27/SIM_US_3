using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.Purchasing.Aggregates;

namespace SIM_US_3.Domain.Purchasing.Interfaces;

public interface IPurchaseRepository : IRepository<Purchase>
{
    Task<IEnumerable<Purchase>> GetByUserIdAsync(int userID);
    Task<IEnumerable<Purchase>> GetByPurchaseStatusIdAsync(int statusId);
}