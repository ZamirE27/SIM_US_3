using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetByUserIdAsync (int userId);
}