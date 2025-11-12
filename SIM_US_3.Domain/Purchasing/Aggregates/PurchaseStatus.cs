namespace SIM_US_3.Domain.Models;

public class PurchaseStatus
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Purchase> Purchases { get; set; } = new List<Purchase>();
}