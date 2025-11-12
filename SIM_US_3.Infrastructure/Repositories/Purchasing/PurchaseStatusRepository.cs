using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Models;
using SIM_US_3.Domain.Models.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.Purchasing;

public class PurchaseStatusRepository : Repository<PurchaseStatus>, IPurchaseStatusRepository
{
    public PurchaseStatusRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<PurchaseStatus?> GetByNameAsync(string name)
    {
        return await _dbset
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == name);
    }
}