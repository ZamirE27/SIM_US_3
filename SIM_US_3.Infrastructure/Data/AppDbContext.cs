using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Models;

namespace SIM_US_3.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User>  Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<DocType> DocTypes => Set<DocType>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<PurchaseDetail> PurchaseDetails => Set<PurchaseDetail>();
    public DbSet<PurchaseStatus> PurchaseStatuses => Set<PurchaseStatus>();
}