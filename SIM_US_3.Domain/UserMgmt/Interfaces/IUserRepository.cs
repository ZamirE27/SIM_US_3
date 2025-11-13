using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.Models;

namespace SIM_US_3.Domain.UserMgmt.Interfaces;

public interface  IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetByRoleAsync(string role);
}