using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Models;
using SIM_US_3.Domain.UserMgmt.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.UserMgmt;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbset
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<User>> GetByRoleAsync(string role)
    {
        return await _dbset
            .Include(u => u.Role)
            .Where(u => u.Role.Name == role)
            .ToListAsync();
    }
}