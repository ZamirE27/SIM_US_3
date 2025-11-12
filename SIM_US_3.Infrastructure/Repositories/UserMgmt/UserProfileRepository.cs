using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Models;
using SIM_US_3.Domain.Models.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.UserMgmt;

public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserProfile?> GetByUserIdAsync(int userId)
    {
        return await _dbset
            .AsNoTracking()
            .FirstOrDefaultAsync(up => up.Id == userId);
    }

    public async Task<IEnumerable<UserProfile>> SearchProfileByNameAsync(string name)
    {
        return await _dbset
            .Where(up => up.Name.ToLower() == name.ToLower())
            .ToListAsync();
    }
}