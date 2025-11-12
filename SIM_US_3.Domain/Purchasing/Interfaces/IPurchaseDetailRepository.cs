using SIM_US_3.Domain.Interfaces;

namespace SIM_US_3.Domain.Models.Interfaces;

public interface IPurchaseDetailRepository : IRepository<PurchaseDetail>
{
    Task<IEnumerable<PurchaseDetail>> GetDetailsByPurchase (int purchaseId);
}