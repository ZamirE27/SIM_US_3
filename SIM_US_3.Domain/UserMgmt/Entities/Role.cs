using SIM_US_3.Domain.Models;

namespace SIM_US_3.Domain.UserMgmt.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<User> Users { get; set; } = new List<User>();
}