using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IUserProfileRepository : IRepository<UserProfile>
{
    Task<UserProfile?> GetByUserIdAsync(int userId);
    Task<IEnumerable<UserProfile>> SearchProfileByNameAsync(string name);
}