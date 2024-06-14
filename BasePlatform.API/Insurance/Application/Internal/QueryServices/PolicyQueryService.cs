using BasePlatform.API.Insurance.Domain.Model.Queries;
using BasePlatform.API.Insurance.Domain.Repositories;
using BasePlatform.API.Insurance.Domain.Services;
using BasePlatform.API.Properties.Domain.Model.Queries;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Insurance.Application.Internal.QueryServices;

public class PolicyQueryService(IPolicyRepository policyRepository): IPolicyQueryService
{
    public async Task<IEnumerable<Policy>> Handle(GetAllPoliciesQuery query)
    {
        return await policyRepository.ListAsync();
    }

    public async Task<Policy?> Handle(GetPolicyByIdQuery query)
    {
        return await policyRepository.FindByIdAsync(query.Id);
    }
}