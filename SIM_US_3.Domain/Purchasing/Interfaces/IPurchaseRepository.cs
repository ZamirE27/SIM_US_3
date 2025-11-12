using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IPurchaseRepository : IRepository<Purchase>
{
    Task<IEnumerable<Purchase>> GetByUserIdAsync(int userID);
    Task<IEnumerable<Purchase>> GetByPurchaseStatusIdAsync(int statusId);
}