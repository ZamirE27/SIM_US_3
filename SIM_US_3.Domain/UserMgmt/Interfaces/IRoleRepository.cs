using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    public Task<Role?> GetByNameAsync(string name);
}