using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.ProductMgmt.Aggregates;

namespace SIM_US_3.Domain.ProductMgmt.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetCategoryByNameAsync(string name);
}