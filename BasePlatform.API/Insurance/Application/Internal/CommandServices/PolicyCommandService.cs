using BasePlatform.API.Insurance.Domain.Model.Commands;
using BasePlatform.API.Insurance.Domain.Repositories;
using BasePlatform.API.Insurance.Domain.Services;
using BasePlatform.API.Shared.Domain.Repositories;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Insurance.Application.Internal.CommandServices;

public class PolicyCommandService(IPolicyRepository policyRepository, IUnitOfWork unitOfWork): IPolicyCommandService
{
    public async Task<Policy?> Handle(CreatePolicyCommand command)
    {
        var policy = new Policy(
            command.Costumer, 
            command.ProductId, 
            command.Address, 
            command.Dni, 
            command.Age
            );
        var policies = await policyRepository.FindByCostumerAsync(command.Costumer);
        var productPolicies = await policyRepository.FindByProductIdAsync(command.ProductId);
        if (policies.Any() && productPolicies.Any()) throw new Exception("Policy already exists");
        await policyRepository.AddAsync(policy);
        await unitOfWork.CompleteAsync();
        return policy;
    }
}