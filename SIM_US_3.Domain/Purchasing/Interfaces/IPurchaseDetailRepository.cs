using SIM_US_3.Domain.Common;
using SIM_US_3.Domain.Purchasing.Aggregates;

namespace SIM_US_3.Domain.Purchasing.Interfaces;

public interface IPurchaseDetailRepository : IRepository<PurchaseDetail>
{
    Task<IEnumerable<PurchaseDetail>> GetDetailsByPurchase (int purchaseId);
}