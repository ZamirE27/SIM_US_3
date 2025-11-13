using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.Purchasing.Aggregates;

namespace SIM_US_3.Domain.Purchasing.Interfaces;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetByUserIdAsync (int userId);
}