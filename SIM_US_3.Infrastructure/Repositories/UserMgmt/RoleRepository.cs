using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.UserMgmt.Entities;
using SIM_US_3.Domain.UserMgmt.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.UserMgmt;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _dbset
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == name);
    }
}