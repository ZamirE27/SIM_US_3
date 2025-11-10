using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Models;
using SIM_US_3.Domain.Models.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.ProductMgmt;

public class ProductRepository : Repository<Product>,IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
    {
        return await _dbset.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
}