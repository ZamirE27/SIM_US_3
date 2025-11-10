using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}