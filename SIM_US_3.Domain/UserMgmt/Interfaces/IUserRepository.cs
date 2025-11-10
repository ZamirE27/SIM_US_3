using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface  IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetByRoleAsync(string role);
}