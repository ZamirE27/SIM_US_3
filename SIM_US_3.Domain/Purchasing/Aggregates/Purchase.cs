using SIM_US_3.Domain.ValueObjects;

namespace SIM_US_3.Domain.Models;

public class Purchase
{
    public int Id { get; private  set; }
    public int UserId { get; private  set; }
    public DateTime Date { get; private  set; }

    public int StatusId { get; private  set; }
    public PurchaseStatus? Status { get; private  set; }
    
    public ShippingAddress ShippingAddress { get; private  set; }
    public decimal TotalPrice { get; private  set; }

    private List<PurchaseDetail> _details = new();
    public IReadOnlyList<PurchaseDetail>  Details => _details.AsReadOnly();
    protected Purchase()
    {}
    public static Purchase CreateFromCart(ShoppingCart cart, ShippingAddress address, PurchaseStatus status)
    {
        if (!cart.Items.Any())
            throw new InvalidOperationException("the cart could not be empty.");

        var purchase = new Purchase
        {
            UserId = cart.UserId,
            Date = DateTime.UtcNow,
            StatusId = status.Id,
            ShippingAddress = address,

            _details = cart.Items.Select(item => PurchaseDetail.Create(
                item.ProductId,
                item.Quantity,
                item.PriceAtTimeOfAddition 
            )).ToList()
        };
        
        purchase.CalculateAndSetTotalPrice(); 
        
        return purchase;
    }
    private void CalculateAndSetTotalPrice()
    {
        TotalPrice = _details.Sum(d => d.CalculateSubtotal().Amount);
    }

    public void ChangeStatus(PurchaseStatus newStatus)
    {
        if (Status?.Name == "sent" && newStatus.Name == "cancelled")
            throw new InvalidOperationException("Sent purchase could not be cancelled.");
        
        StatusId = newStatus.Id;
        Status = newStatus;
    }
}
