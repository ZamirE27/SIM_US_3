using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Purchasing.Aggregates;
using SIM_US_3.Domain.Purchasing.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.Purchasing;

public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Purchase>> GetByUserIdAsync(int userID)
    {
        return await _dbset
            .AsNoTracking()
            .Where(p => p.UserId == userID)
            .ToListAsync();
    }

    public async Task<IEnumerable<Purchase>> GetByPurchaseStatusIdAsync(int statusId)
    {
        return await _dbset
            .AsNoTracking()
            .Include(p => p.User)
            .Where(p => p.StatusId == statusId)
            .ToListAsync();
    }
}