using BasePlatform.API.Insurance.Domain.Model.ValueObjects;
using BasePlatform.API.Shared.Domain.Repositories;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Insurance.Domain.Repositories;

public interface IPolicyRepository: IBaseRepository<Policy>
{
    Task<IEnumerable<Policy>> FindByCostumerAsync(string costumer);
    Task<IEnumerable<Policy>> FindByProductIdAsync(Eproduct productId);
}