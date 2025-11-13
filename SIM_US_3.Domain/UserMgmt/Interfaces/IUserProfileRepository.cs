using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.UserMgmt.Aggregates;

namespace SIM_US_3.Domain.UserMgmt.Interfaces;

public interface IUserProfileRepository : IRepository<UserProfile>
{
    Task<UserProfile?> GetByUserIdAsync(int userId);
    Task<IEnumerable<UserProfile>> SearchProfileByNameAsync(string name);
}