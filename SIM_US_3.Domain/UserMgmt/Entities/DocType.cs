using SIM_US_3.Domain.UserMgmt.Aggregates;

namespace SIM_US_3.Domain.UserMgmt.Entities;

public class DocType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
} 