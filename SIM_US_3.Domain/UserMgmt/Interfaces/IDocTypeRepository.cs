using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IDocTypeRepository : IRepository<DocType>
{
    Task<DocType?> GetByDocTypeAsync(string docType);
}