using SIM_US_3.Domain.ValueObjects;

namespace SIM_US_3.Domain.Purchasing.Aggregates;

public class PurchaseDetail
{
    public int Id { get; private set; }
    
     public int PurchaseId { get; private set; }
     public Purchase? Purchase { get; private set; }
     
     public int ProductId { get; private set; }
     
     public int Quantity { get; private set; }
     public Money UnitPrice { get; private set; }

     protected PurchaseDetail()
     {
     }

     public static PurchaseDetail Create(int productId, int quantity, Money unitPrice)
     {
         if (quantity <= 0)
         {
             throw new ArgumentException("Quantity must  be greater than 0");
         }

         return new PurchaseDetail
         {
             ProductId = productId,
             Quantity = quantity,
             UnitPrice = unitPrice
         };
     }

     public Money CalculateSubtotal()
     {
         var totalAmount = UnitPrice.Amount * Quantity;
         return Money.Create(totalAmount, UnitPrice.Currency);
     }
}