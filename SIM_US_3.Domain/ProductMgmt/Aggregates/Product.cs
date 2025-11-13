using SIM_US_3.Domain.ValueObjects;

namespace SIM_US_3.Domain.ProductMgmt.Aggregates;

public class Product
{
    protected Product() {}
    
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public int Stock { get; private set; }
    public int CategoryId { get; private set; }
    public Category? Category { get; private set; }

    public static Product Create(string name, string description, Money price, int stock, int categoryId)
    {
        if (stock < 0)
        {
            throw new ArgumentException("The initial stock could not be negative.", nameof(stock));
        }

        if (price.Amount <= 0)
        {
            throw new ArgumentException("The price should be major than Cero",  nameof(price));
        }

        return new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock,
            CategoryId = categoryId,
        };
    }

    public void ChangePrice(Money newPrice)
    {
        if (newPrice.Amount <= 0)
        {
            throw new InvalidOperationException("The new price could not be negative.");
        }
        Price = newPrice;
    }

    public void AddStock(int quantity)
    {
        if (quantity < 0)
        {
            RemoveStock(Math.Abs(quantity));
            return;
        }
        Stock += quantity;
    }
    
    public void RemoveStock(int quantity)
    {
        if (Stock - quantity < 0)
        {
            throw new InvalidOperationException($"Stock could not be reduce, current Stuck: {Stock}. Requesting: {quantity}");
        }
        Stock -= quantity;
    }
}