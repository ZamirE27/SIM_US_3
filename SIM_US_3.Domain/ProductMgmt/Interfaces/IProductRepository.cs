using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.ProductMgmt.Aggregates;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
}