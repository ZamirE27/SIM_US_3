namespace SIM_US_3.Domain.Models;

public class Purchase
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public User? User { get; set; }
    
    public DateTime Date { get; set; }
    
    public int StatusId { get; set; }
    public PurchaseStatus? Status { get; set; }
    
    public string ShippingAddress { get; set; }
    public double TotalPrice { get; set; }
    
    
    
}