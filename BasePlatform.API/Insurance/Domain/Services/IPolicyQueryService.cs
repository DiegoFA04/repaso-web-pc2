using BasePlatform.API.Insurance.Domain.Model.Queries;
using BasePlatform.API.Properties.Domain.Model.Queries;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Insurance.Domain.Services;

public interface IPolicyQueryService
{
    Task<IEnumerable<Policy>> Handle(GetAllPoliciesQuery query);
    Task<Policy?> Handle(GetPolicyByIdQuery query);
}