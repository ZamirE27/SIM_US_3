using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.ProductMgmt.Aggregates;
using SIM_US_3.Domain.ProductMgmt.Interfaces;
using SIM_US_3.Infrastructure.Common;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Repositories.ProductMgmt;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        return await _dbset.FirstOrDefaultAsync(c => c.Name == name);
    }
}