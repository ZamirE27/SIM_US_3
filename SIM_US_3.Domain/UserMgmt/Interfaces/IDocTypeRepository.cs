using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.UserMgmt.Entities;

namespace SIM_US_3.Domain.UserMgmt.Interfaces;

public interface IDocTypeRepository : IRepository<DocType>
{
    Task<DocType?> GetByDocTypeAsync(string docType);
}