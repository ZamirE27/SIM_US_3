using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.UserMgmt.Entities;
using SIM_US_3.Domain.UserMgmt.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.UserMgmt;

public class DocTypeRepository : Repository<DocType>, IDocTypeRepository
{
    public DocTypeRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<DocType?> GetByDocTypeAsync(string docType)
    {
        return await _dbset
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Name== docType);
    }
}