using BasePlatform.API.Insurance.Domain.Model.Commands;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Insurance.Domain.Services;

public interface IPolicyCommandService
{
    Task<Policy?> Handle(CreatePolicyCommand command);
}