using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Interfaces;
using SIM_US_3.Domain.Models.Interfaces;
using SIM_US_3.Infrastructure.Data;

namespace SIM_US_3.Infrastructure.Common;

public class Repository<T> : IRepository<T> where T : class
{
    protected AppDbContext _dbContext;
    protected DbSet<T> _dbset;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbset = _dbContext.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbset.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _dbset.FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbset.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbset.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _dbset.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}