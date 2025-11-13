using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Purchasing.Aggregates;
using SIM_US_3.Domain.Purchasing.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.Purchasing;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ShoppingCart?> GetByUserIdAsync(int userId)
    {
        return await  _dbset
            .Include(s => s.Items )
            .FirstOrDefaultAsync(s => s.UserId == userId);
    }
}