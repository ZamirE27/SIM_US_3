namespace SIM_US_3.Domain.Models;

public class PurchaseStatus
{
    public int Id { get; private  set; }
    public string Name { get; private set; }

    public List<Purchase> Purchases { get; private set; } = new List<Purchase>();
    
    protected PurchaseStatus(){}

    public static PurchaseStatus Create(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("the status purchase's name is required");
        
        return new PurchaseStatus{Name =  name};
    }
}