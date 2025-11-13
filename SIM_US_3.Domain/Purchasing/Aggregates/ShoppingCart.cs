using SIM_US_3.Domain.ValueObjects;

namespace SIM_US_3.Domain.Purchasing.Aggregates;

public class ShoppingCart
{
    public int Id { get; private set; }
    public int UserId { get; private set; }

    private readonly List<CartItem> _items = new();
    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

    public Money TotalPrice
    {
        get
        {
            if (!_items.Any())
            {
                return Money.Create(0, "USD");
            }

            var totalAmount = _items.Sum(item => item.CalculateSubtotal().Amount);
            return Money.Create(totalAmount, _items.First().PriceAtTimeOfAddition.Currency);
        }
    }
    protected ShoppingCart() { }

    
    public static ShoppingCart Create(int userId)
    {
        
        return new ShoppingCart { UserId = userId };
    }
    

    public void AddItem(int productId, Money currentProductPrice, int quantity)
    {
        if (quantity <= 0) 
            throw new ArgumentException("the quantity to add should be positive");
        
        var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.UpdateQuantity(existingItem.Quantity + quantity);
        }
        else
        { 
            var newItem = CartItem.Create(productId, currentProductPrice, quantity);
            _items.Add(newItem);
        }
    }
    
    public void UpdateItemQuantity(int productId, int newQuantity)
    {
        var itemToUpdate = _items.FirstOrDefault(i => i.ProductId == productId);
        
        if (itemToUpdate == null) 
            throw new InvalidOperationException($"Product with ID {productId} was not found ion the cart.");
            
        if (newQuantity <= 0)
        {
            RemoveItem(productId);
            return;
        }
        
        itemToUpdate.UpdateQuantity(newQuantity);
    }
    
    public void RemoveItem(int productId)
    {
        var itemToRemove = _items.FirstOrDefault(i => i.ProductId == productId);
        if (itemToRemove != null)
        {
            _items.Remove(itemToRemove);
        }
    }
    
    public void Clear()
    {
        _items.Clear();
    }
    
    public Purchase Checkout(ShippingAddress address, PurchaseStatus status)
    {
        if (!_items.Any())
        {
            throw new InvalidOperationException("the purchase could not be finished because it is empty.");
        }
        
        return Purchase.CreateFromCart(this, address, status);
    }
}
