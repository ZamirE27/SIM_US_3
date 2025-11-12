namespace SIM_US_3.Domain.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
    public int DocTypeId { get; set; }
    public DocType? DocType { get; set; }
    
    public int UserId { get; set; }
    public User? User { get; set; }
    
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    
}