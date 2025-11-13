using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SIM_US_3.Domain.Models;
using SIM_US_3.Domain.ProductMgmt.Aggregates;
using SIM_US_3.Domain.Purchasing.Aggregates;
using SIM_US_3.Domain.UserMgmt.Aggregates;
using SIM_US_3.Domain.UserMgmt.Entities;
using SIM_US_3.Domain.ValueObjects;

namespace SIM_US_3.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    //UserMgmt
    public DbSet<User>  Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<DocType> DocTypes => Set<DocType>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    
    //ProductMgmt
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    
    //Purchasing
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<PurchaseStatus> PurchaseStatuses => Set<PurchaseStatus>();
    public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.OwnsOne(p => p.Price, money =>
            {
                money.Property(m => m.Amount).HasColumnName("Price_Amount").HasColumnType("decimal(18,2)").IsRequired();
                money.Property(m => m.Currency).HasColumnName("Price_Currency").HasMaxLength(3).IsRequired();
            });
            entity.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.OwnsOne(p => p.ShippingAddress, address =>
            {
                address.Property(a => a.Street).HasColumnName("Shipping_Street").HasMaxLength(250).IsRequired();
                address.Property(a => a.City).HasColumnName("Shipping_City").HasMaxLength(100).IsRequired();
                address.Property(a => a.Country).HasColumnName("Shipping_Country").HasMaxLength(100).IsRequired();
                address.Property(a => a.ZipCode).HasColumnName("Shipping_ZipCode").HasMaxLength(20);
            });
            entity.HasOne(p => p.Status).WithMany(s => s.Purchases).HasForeignKey(p => p.StatusId);
            entity.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
            
            entity.HasMany(p => p.Details)
                .WithOne()
                .HasForeignKey("PurchaseId");

            entity.OwnsMany(p => p.Details)
                .OwnsOne(d => d.UnitPrice, money =>
                {
                    money.Property(m => m.Amount).HasColumnName("Unit_Price_Amount").HasColumnType("decimal(18,2)")
                        .IsRequired();
                    money.Property(m => m.Currency).HasColumnName("Unit_Currency").HasMaxLength(3).IsRequired();
                });
        });
        

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey("ShoppingCartId");

            entity.OwnsMany(s => s.Items)
                .OwnsOne(i => i.PriceAtTimeOfAddition, money =>
                {
                    money.Property(m => m.Amount).HasColumnName("PriceAtTimeOfAddition_Amount")
                        .HasColumnType("decimal(18, 2)").IsRequired();
                    money.Property(m => m.Currency).HasColumnName("PriceAtTimeOfAddition_Currency").HasMaxLength(3)
                        .IsRequired();
                });
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasOne(up => up.DocType).WithMany(dt => dt.UserProfiles).HasForeignKey(up => up.DocTypeId);
            entity.HasOne(up => up.User).WithOne().HasForeignKey<UserProfile>(up => up.UserId);
        });
    }
}