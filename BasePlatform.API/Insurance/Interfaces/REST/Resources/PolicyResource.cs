using BasePlatform.API.Insurance.Domain.Model.ValueObjects;

namespace BasePlatform.API.Insurance.Interfaces.REST.Resources;

public record PolicyResource(
    int Id,
    string Costumer, 
    Eproduct ProductId, 
    string Address, 
    string Dni, 
    int Age
    );