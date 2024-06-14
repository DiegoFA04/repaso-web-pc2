using BasePlatform.API.Insurance.Interfaces.REST.Resources;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Insurance.Interfaces.REST.Transform;

public static class PolicyResourceFromEntityAssembler
{
    public static PolicyResource ToResourceFromEntity(Policy policy)
    {
        return new PolicyResource(
            policy.Id,
            policy.Costumer,
            policy.ProductId,
            policy.Address,
            policy.Dni,
            policy.Age
        );
    }
}