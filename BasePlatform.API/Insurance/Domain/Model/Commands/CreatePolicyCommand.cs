using BasePlatform.API.Insurance.Domain.Model.ValueObjects;

namespace BasePlatform.API.Insurance.Domain.Model.Commands;

public record CreatePolicyCommand(
    string Costumer,
    Eproduct ProductId,
    string Address,
    string Dni,
    int Age
    );