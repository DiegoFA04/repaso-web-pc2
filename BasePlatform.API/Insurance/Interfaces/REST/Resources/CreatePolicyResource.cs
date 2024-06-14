namespace BasePlatform.API.Insurance.Interfaces.REST.Resources;

public record CreatePolicyResource(
    string Costumer, 
    int ProductId, 
    string Address, 
    string Dni, 
    int Age
    );