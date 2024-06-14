using BasePlatform.API.Insurance.Domain.Model.ValueObjects;
using BasePlatform.API.Insurance.Domain.Repositories;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Insurance.Infrastructure.Persistence.EFC.Repositories;

public class PolicyRepository(AppDbContext context): BaseRepository<Policy>(context), IPolicyRepository
{
    public async Task<IEnumerable<Policy>> FindByCostumerAsync(string costumer)
    {
        return await Context.Set<Policy>()
            .Where(policy => policy.Costumer == costumer)
            .ToListAsync();
    }

    public async Task<IEnumerable<Policy>> FindByProductIdAsync(Eproduct productId)
    {
        return await Context.Set<Policy>()
            .Where(policy => policy.ProductId == productId)
            .ToListAsync();
    }
}