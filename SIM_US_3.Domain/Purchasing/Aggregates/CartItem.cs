using SIM_US_3.Domain.ValueObjects;

namespace SIM_US_3.Domain.Purchasing.Aggregates;

public class CartItem 
{
    public int Id { get; private set; } 
    public int ProductId { get; private set; } 
    
    
    public Money PriceAtTimeOfAddition { get; private set; }
    
    public int Quantity { get; private set; }

    
    protected CartItem() { }

    
    public static CartItem Create(int productId, Money price, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("the quantity should be positive");

        return new CartItem
        {
            ProductId = productId,
            PriceAtTimeOfAddition = price,
            Quantity = quantity
        };
    }
    
    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity < 0)
        {
            throw new ArgumentException("the  quantity should be positive.");
        }
        Quantity = newQuantity;
    }
    
    public Money CalculateSubtotal()
    {
        return Money.Create(PriceAtTimeOfAddition.Amount * Quantity, PriceAtTimeOfAddition.Currency);
    }
}