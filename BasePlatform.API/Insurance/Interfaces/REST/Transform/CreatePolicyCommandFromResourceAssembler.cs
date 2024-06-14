using BasePlatform.API.Insurance.Domain.Model.Commands;
using BasePlatform.API.Insurance.Domain.Model.ValueObjects;
using BasePlatform.API.Insurance.Interfaces.REST.Resources;

namespace BasePlatform.API.Insurance.Interfaces.REST.Transform;

public static class CreatePolicyCommandFromResourceAssembler
{
    public static CreatePolicyCommand ToCommandFromResource(CreatePolicyResource resource)
    {
        return new CreatePolicyCommand(
            resource.Costumer,
            (Eproduct)resource.ProductId,
            resource.Address,
            resource.Dni,
            resource.Age
        );
    }
}