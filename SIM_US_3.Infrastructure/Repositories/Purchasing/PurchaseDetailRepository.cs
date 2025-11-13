using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Purchasing.Aggregates;
using SIM_US_3.Domain.Purchasing.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.Purchasing;

public class PurchaseDetailRepository : Repository<PurchaseDetail>,IPurchaseDetailRepository
{
    public PurchaseDetailRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<PurchaseDetail>> GetDetailsByPurchase(int purchaseId)
    {
        return await _dbset
            .Where(x => x.PurchaseId == purchaseId)
            .ToListAsync();
    }
}