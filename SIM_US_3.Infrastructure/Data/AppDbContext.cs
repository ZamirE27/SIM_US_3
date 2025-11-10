using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Models;

namespace SIM_US_3.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    DbSet<User>  Users => Set<User>();
    DbSet<Role> Roles => Set<Role>();
    DbSet<DocType> DocTypes => Set<DocType>();
    DbSet<Category> Categories => Set<Category>();
    DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    DbSet<Product> Products => Set<Product>();
    DbSet<Purchase> Purchases => Set<Purchase>();
    DbSet<PurchaseDetail> PurchaseDetails => Set<PurchaseDetail>();
    DbSet<PurchaseStatus> PurchaseStatuses => Set<PurchaseStatus>();
}